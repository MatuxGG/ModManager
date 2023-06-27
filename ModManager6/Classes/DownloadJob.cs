using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class DownloadJob
    {
        public FileDownloader Downloader { get; }
        public long AccountedBytes { get; set; }
        public DownloadLine Line { get; set; }

        public DownloadJob(FileDownloader downloader, DownloadLine line)
        {
            Downloader = downloader;
            Line = line;
        }
    }
}
