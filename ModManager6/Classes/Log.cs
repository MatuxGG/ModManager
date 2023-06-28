using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static Stopwatch stopwatch;
        public static string formattedTime;

        public static void logNewLine()
        {
            bool written = false;
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
            bool written = false;
            while (written == false)
            {
                try
                {
                    File.AppendAllText(logFile, "[" + DateTime.UtcNow + "][" + className + "] " + line + Environment.NewLine);
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

        public static void startTimer()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public static string endTimer()
        {
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            return string.Format("{0}:{1:D2}:{2:D2}", (int)elapsedTime.TotalMinutes, elapsedTime.Seconds, elapsedTime.Milliseconds / 10);
        }

        public static void logTime(string line, string className)
        {
            log(line + " (" + endTimer() + ")", className);
        } 

        // TODO: Log to serv 
    }
}
