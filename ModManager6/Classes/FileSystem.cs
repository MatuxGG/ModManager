using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager6.Classes
{
    public class FileSystem
    {
        public static void DirectoryCreate(string dirName)
        {
            try
            {
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs = true)
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void DirectoryCopyWithoutReplacement(string sourceDirName, string destDirName)
        {
            try
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
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void DirectoryDelete(string dirName)
        {
            try
            {
                if (Directory.Exists(dirName))
                {
                    Directory.Delete(dirName, true);
                }

            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            } 
        }

        public static void FileDelete(string fileName)
        {
            try
            {

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static void FileCopy(string source, string destination)
        {
            try
            {

                if (File.Exists(source) && !File.Exists(destination))
                {
                    File.Copy(source, destination);
                }
            }
            catch (Exception e)
            {
                Log.logExceptionToServ(e);
            }
        }

        public static string StringReplaceVars(string text)
        {
            try
            {
                text = text.Replace("FILEURL", ModManager.fileURL);
                text = text.Replace("APIURL", ModManager.apiURL);
                text = text.Replace("SERVERURL", ModManager.serverURL);
                text = text.Replace("APPPATH", ModManager.appPath);
                text = text.Replace("APPDATAPATH", ModManager.appDataPath);
                text = text.Replace("TEMPPATH", ModManager.tempPath);
                return text;
            } catch (Exception e)
            {
                Log.logExceptionToServ(e);
                return null;
            }
        }
    }
}
