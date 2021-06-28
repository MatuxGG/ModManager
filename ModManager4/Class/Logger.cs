using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager4.Class
{
    public class Logger
    {
        public string logFile { get; set; }
        public Logger()
        {
            this.logFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ModManager\\log.txt";
            
            if (File.Exists(logFile))
            {
                var lineCount = File.ReadLines(logFile).Count();
                if (lineCount > 10000)
                {
                    DateTime utcDate = DateTime.UtcNow;
                    File.WriteAllText(logFile, "Logs cleaned (Date : "+ utcDate + ")\n");
                }
            }
        }

        public void log(string line)
        {
            Boolean written = false;
            while (written == false) {
                try
                {
                    File.AppendAllText(logFile, line + Environment.NewLine);
                    written = true;
                }
                catch
                {
                    written = false;
                }
            }
            
        }

        public void debug(string s)
        {
            MessageBox.Show(s, "DEBUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
