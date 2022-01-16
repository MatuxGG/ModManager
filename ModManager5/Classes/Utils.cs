﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static void log(string line)
        {
            Boolean written = false;
            while (written == false)
            {
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

        public static void logE(string line)
        {
            Utils.log("[Error]" + line);
        }

        public static void debug(string s)
        {
            MessageBox.Show(s, "DEBUG", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
