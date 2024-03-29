﻿using Octokit;
using Svg;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Speech.Recognition.SrgsGrammar;
using System.Text;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class Utils
    {
        public static string logFile = ModManager.appDataPath + @"\logs.txt";

        public static void CleanLogs()
        {
            if (File.Exists(logFile))
            {
                var lineCount = File.ReadLines(logFile).Count();
                if (lineCount > 10000)
                {
                    DateTime utcDate = DateTime.UtcNow;
                    File.WriteAllText(logFile, "Logs cleaned (Date : " + utcDate + ")\n");
                }
            }
        }

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
                    File.AppendAllText(logFile, "[" + DateTime.UtcNow + "][" + className + "]" + Utils.getTabs(className) + line + Environment.NewLine);
                    written = true;
                }
                catch
                {
                    written = false;
                }
            }
        }

        public static void logE(string line, string className)
        {
            Boolean written = false;
            while (written == false)
            {
                try
                {
                    File.AppendAllText(logFile, "[" + DateTime.UtcNow + "][" + className + "] ERROR:" + Utils.getTabs(className) + line + Environment.NewLine);
                    written = true;
                }
                catch
                {
                    written = false;
                }
            }
        }

        public static void logEx(Exception e, string className)
        {
            Utils.logE("Error: " + e.Message, className);
            Utils.logE("Source: " + e.Source, className);
        }

        public static void logToServ(Exception e, string className)
        {
            logToServ("Mod Manager " + ModManager.visibleVersion + " - Client id: " + ConfigManager.config.supportId + " - Class: " + className + " - Message: " + e.Message + " - Source = " + e.Source);
        }

        public static void logToServ(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                using (var client = Utils.getClient())
                {
                    var values = new NameValueCollection();
                    values["text"] = text;

                    var response = client.UploadValues(ModManager.apiURL + "/log", values);

                    var responseString = Encoding.Default.GetString(response);

                }
            }

        }

        // Spec : str <= 15
        public static string getTabs(string str)
        {
            int l = str.Length;
            if (l < 5)
            {
                return "\t\t\t\t";
            } else if (l < 9)
            {
                return "\t\t\t";
            } else if (l < 13)
            {
                return "\t\t";
            } else
            {
                return "\t";
            }

        }

        public static void debug(string s)
        {
            MessageBox.Show(s, "DEBUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static WebClient getClient()
        {
            WebClient client = new WebClient();
            client.Proxy = GlobalProxySelection.GetEmptyWebProxy();
            return client;
        }

        public static Bitmap getOrDownload(string serverPath, string localPath)
        {
            try
            {
                if (!File.Exists(localPath))
                {
                    using (var client = Utils.getClient())
                    {
                        client.DownloadFile(serverPath, localPath);
                    }
                }

            }
            catch (Exception e)
            {
                Utils.logEx(e, "getOrDownload");
                Utils.logToServ(e, "getOrDownload");
            }

            return new Bitmap(localPath);
        }

        public static void DirectoryCreate(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
        }
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                if (!new FileInfo(tempPath).Exists)
                {
                    file.CopyTo(tempPath, false);
                }
                else
                {
                    file.CopyTo(tempPath, true);
                }
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        public static void DirectoryCopyWithoutReplacement(string sourceDirName, string destDirName)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                if (!new FileInfo(tempPath).Exists)
                {
                    file.CopyTo(tempPath, false);
                }
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopyWithoutReplacement(subdir.FullName, tempPath);
            }
        }

        public static void DirectoryDelete(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                Directory.Delete(dirName, true);
            }
        }

        public static void FileDelete(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public static void FileCopy(string source, string destination)
        {
            if (File.Exists(source) && !File.Exists(destination))
            {
                File.Copy(source, destination);
            }
        }

    }
}
