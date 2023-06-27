using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class DownloadProgress
    {
        public long BytesRead { get; private set; }
        public long TotalBytes { get; private set; }
        public TimeSpan ElapsedTime { get; set; }

        public DownloadProgress(long bytesRead, long totalBytes, TimeSpan elapsedTime)
        {
            BytesRead = bytesRead;
            TotalBytes = totalBytes;
            ElapsedTime = elapsedTime;
        }
    }
}
