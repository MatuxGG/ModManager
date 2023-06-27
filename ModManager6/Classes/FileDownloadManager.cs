using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Classes
{
    public static class FileDownloadManager
    {
        private static BackgroundWorker bw;
        private static List<DownloadLine> downloadLines;
        private static Label statusLabel;
        private static long totalBytesRead = 0;
        private static long totalBytesToRead = 0;
        private static TimeSpan totalElapsedTime;
        private static object syncLock = new object();
        private static HttpClient client = new HttpClient();
        private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private static ModManager thisModManager;
        public static event Action DownloadCompleted;

        public static void load(ModManager modManager)
        {
            thisModManager = modManager;
        }

        public static void download(List<DownloadLine> lines, Label label)
        {
            downloadLines = lines;
            statusLabel = label;

            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync();
        }

        private static async Task<long> GetContentLengthAsync(string url)
        {
            using var request = new HttpRequestMessage(HttpMethod.Head, url);
            using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationTokenSource.Token);

            response.EnsureSuccessStatusCode();

            return response.Content.Headers.ContentLength ?? 0;
        }

        private static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Calcul du totalBytesToRead avant de démarrer les téléchargements
            totalBytesToRead = downloadLines.Sum(line => GetContentLengthAsync(line.source).GetAwaiter().GetResult());

            var downloadJobs = downloadLines.Select(line =>
            {
                var downloader = new FileDownloader(client, cancellationTokenSource);
                return new DownloadJob(downloader, line);
            }).ToList();

            var tasks = downloadJobs.Select(job =>
            {
                job.Downloader.OnProgressChanged += (progress) =>
                {
                    lock (syncLock)
                    {
                        var newBytesRead = progress.BytesRead - job.AccountedBytes;
                        totalBytesRead += newBytesRead;
                        totalElapsedTime += progress.ElapsedTime;
                        job.AccountedBytes = progress.BytesRead;
                        bw.ReportProgress(0, new DownloadProgress(totalBytesRead, totalBytesToRead, totalElapsedTime));
                    }
                };
                // Start the download on a thread pool thread
                return Task.Run(() => job.Downloader.DownloadAsync(job.Line.source, job.Line.target));
            }).ToArray();

            try
            {
                // Wait for all downloads to complete
                Task.WaitAll(tasks);
            }
            catch (AggregateException ex)
            {
                // Handle any exceptions that were thrown by the download tasks
                foreach (var innerEx in ex.InnerExceptions)
                {
                    Console.WriteLine(innerEx.Message);
                }
            }

            // Trigger the DownloadCompleted event after all downloads are complete
            DownloadCompleted?.Invoke();
        }

        public static string FormatByteSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        private static void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progress = (DownloadProgress)e.UserState;
            var percentage = (double)progress.BytesRead / progress.TotalBytes * 100;
            var bytesReadFormatted = FormatByteSize(progress.BytesRead);
            var totalBytesFormatted = FormatByteSize(progress.TotalBytes);
            var speed = progress.BytesRead / progress.ElapsedTime.TotalSeconds;
            var speedFormatted = FormatByteSize((long)speed);

            thisModManager.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = Translator.get("Downloading content, please wait...\nCURRENT / TOTAL (PERCENT%)\nSpeed: SPEED/s")
                    .Replace("CURRENT", bytesReadFormatted)
                    .Replace("TOTAL", totalBytesFormatted)
                    .Replace("PERCENT", percentage.ToString("F2"))
                    .Replace("SPEED", speedFormatted);
            });
        }

        private static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                thisModManager.Invoke((MethodInvoker)delegate
                {
                    statusLabel.Text = e.Error.Message;
                });
            }
            else
            {
                thisModManager.Invoke((MethodInvoker)delegate
                {
                    statusLabel.Text = Translator.get("Installation complete");
                });
                
            }

        }
    }
}
