using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Classes
{
    public class FileDownloader
    {
        private HttpClient client;
        private Stopwatch stopwatch;
        private CancellationTokenSource cancellationTokenSource;
        public delegate void ProgressChangedHandler(DownloadProgress progress);
        public event ProgressChangedHandler OnProgressChanged;
        private DateTime lastUpdateTime;

        public FileDownloader(HttpClient client, CancellationTokenSource cancellationTokenSource)
        {
            this.client = client;
            this.cancellationTokenSource = cancellationTokenSource;
            stopwatch = new Stopwatch();
            lastUpdateTime = DateTime.MinValue;
        }

        public async Task DownloadAsync(string url, string destinationPath)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationTokenSource.Token);

                response.EnsureSuccessStatusCode();

                var contentLength = response.Content.Headers.ContentLength;

                using var contentStream = await response.Content.ReadAsStreamAsync();
                using var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);

                var totalBytesRead = 0L;
                var buffer = new byte[8192];
                var isMoreToRead = true;

                stopwatch.Start();

                do
                {
                    var bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, cancellationTokenSource.Token);

                    if (bytesRead == 0)
                    {
                        isMoreToRead = false;
                    }
                    else
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);

                        totalBytesRead += bytesRead;

                        if ((DateTime.Now - lastUpdateTime).TotalSeconds >= 1)
                        {
                            lastUpdateTime = DateTime.Now;
                            OnProgressChanged?.Invoke(new DownloadProgress(totalBytesRead, contentLength.Value, stopwatch.Elapsed));
                        }
                    }
                }
                while (isMoreToRead);

                stopwatch.Stop();
            }
            catch (Exception e)
            {
                // Handle exception
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }

        public void CancelDownload()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
