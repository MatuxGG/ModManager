using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace ModManager6.Classes
{
    public static class Downloader
    {
        private static List<DownloadLine> downloadLines;
        private static string logText;

        private static long totalBytes;
        private static long bytesRead;
        private static long bytesReadLastTime;

        private static HttpClient client;
        private static Timer timer;
        private static long elapsedTime;
        private static List<Task> tasks; // TODO: cancel tasks

        private const long packetSize = 1024 * 1024; // 1 MB

        public static void load()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        public static async Task<String> downloadString(string url)
        {
            using (HttpClient cli = new HttpClient())
            {
                HttpResponseMessage response = await cli.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Log.logError("ModManager", "Http Error", response.StatusCode.ToString());
                }
            }
            return "";
        }

        public static async Task<bool> downloadPath(string url, string path)
        {
            using (HttpClient cli = new HttpClient())
            {
                HttpResponseMessage response = await cli.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    File.Delete(path);
                    File.WriteAllText(path, result);
                    return true;
                }
                else
                {
                    Log.logError("ModManager", "Http Error", response.StatusCode.ToString());
                }
            }
            return false;
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

        public static async Task<long> GetFileSizeAsync(string url)
        {
            HttpResponseMessage response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
            if (response.IsSuccessStatusCode)
            {
                return response.Content.Headers.ContentLength ?? 0;
            }
            else
            {
                return 0;
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime += 1;
            long curRead = bytesRead - bytesReadLastTime;
            bytesReadLastTime = bytesRead;
            var bytesReadFormatted = FormatByteSize(bytesRead);
            var totalBytesFormatted = FormatByteSize(totalBytes);
            double percentage = (double)bytesRead / totalBytes * 100;
            var speedFormatted = FormatByteSize((long)curRead);

            ModManagerUI.StatusLabel.Invoke((Action)(() =>
            {
                ModManagerUI.StatusLabel.Text = Translator.get(logText + "\nCURRENT / TOTAL (PERCENT%)\nSpeed: SPEED/s")
                    .Replace("CURRENT", bytesReadFormatted)
                    .Replace("TOTAL", totalBytesFormatted)
                    .Replace("PERCENT", percentage.ToString("F2"))
                    .Replace("SPEED", speedFormatted);
            }));
        }

        public static async Task DownloadFiles(string text, List<DownloadLine> lines)
        {
            logText = text;

            if (timer.Enabled)
            {
                timer.Stop();
            }
            timer.Start();

            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = true
            };

            using (client = new HttpClient(handler))
            {
                // Calc totals
                downloadLines = lines;
                totalBytes = 0;
                foreach (DownloadLine dl in downloadLines)
                {
                    dl.size = await GetFileSizeAsync(dl.source);
                    totalBytes += dl.size;
                }


                tasks = new List<Task>() { };
                foreach (DownloadLine dl in downloadLines)
                {
                    tasks.Add(DownloadFile(dl));
                }
                await Task.WhenAll(tasks);
            }
            timer.Stop();
        }

        private static long GetPacketSize(long fileSize)
        {
            return fileSize <= packetSize ? fileSize : packetSize;
        }

        public static async Task DownloadFile(DownloadLine dl)
        {
            long currentBytesRead = 0;
            bytesReadLastTime = 0;
            using (FileStream fileStream = new FileStream(dl.target, FileMode.OpenOrCreate, FileAccess.Write))
            {
                bool moreToRead = true;

                while (moreToRead)
                {
                    try
                    {
                        long bytesToRead = Math.Min(dl.size - currentBytesRead, GetPacketSize(dl.size));

                        if (bytesToRead == 0)
                        {
                            moreToRead = false;
                            continue;
                        }

                        HttpRequestMessage request = new HttpRequestMessage { RequestUri = new Uri(dl.source) };
                        request.Headers.Range = new RangeHeaderValue(currentBytesRead, currentBytesRead + bytesToRead - 1);
                        
                        using (HttpResponseMessage response = await client.SendAsync(request))
                        {
                            response.EnsureSuccessStatusCode();

                            byte[] buffer = await response.Content.ReadAsByteArrayAsync();
                            await fileStream.WriteAsync(buffer, 0, buffer.Length);

                            currentBytesRead += buffer.Length;
                            bytesRead += bytesToRead;
                        }
                    } catch (HttpRequestException)
                    {
                        if (timer.Enabled)
                        {
                            timer.Stop();
                        }
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        if (!timer.Enabled)
                        {
                            timer.Start();
                        }
                    }
                    
                }
            }
        }
    }
}
