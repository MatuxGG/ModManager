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
        }

        public void log(string line)
        {
            File.AppendAllText(logFile, line + Environment.NewLine);
        }

        public void debug(string s)
        {
            MessageBox.Show(s, "DEBUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
