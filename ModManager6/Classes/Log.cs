using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager6.Classes
{
    public static class Log
    {
        public static string logFile = ModManager.appDataPath + @"\logs.txt";

        public static void logNewLine()
        {
            Boolean written = false;
            while (written == false)
            {
                try
                {
                    File.AppendAllText(logFile, Environment.NewLine);
                    written = true;
                }
                catch
                {
                    written = false;
                }
            }
        }

        public static void log(string line, string className)
        {
            Boolean written = false;
            while (written == false)
            {
                try
                {
                    File.AppendAllText(logFile, "[" + DateTime.UtcNow + "][" + className + "]" + line + Environment.NewLine);
                    written = true;
                }
                catch
                {
                    written = false;
                }
            }
        }

        public static void debug(string s)
        {
            MessageBox.Show(s, "DEBUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void logError(string classname, string source, string message)
        {
            Log.log("Error: " + source + " -> " + message, classname);
        }

        public static void showError(string classname, string source, string message)
        {
            logError(classname, source, message);
            MessageBox.Show("An error has occured.\nPlease restart Mod Manager and try again.\nIf this happen again, please create a ticket on Mod Manager's support discord server.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(0);
        }

        // TODO: Log to serv 
    }
}
