using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModManager6;
using Octokit;

namespace ModManager6.Classes
{
    public static class Updater
    {
        public static Version latestVersion = null;
        public static Release latestRelease = null;
        public static async Task CheckRunUpdateOnStart()
        {
            await GetGithubVersion();

            if (latestVersion > ModManager.version)
            {
                await updateMM();
            }
        }

        public static async Task updateMM()
        {
            string installerPath = ModManager.tempPath + @"\ModManagerInstaller.exe";
            DialogResult userAction = MessageBox.Show("There is a new version of Mod Manager available. Mod Manager will auto update.\n\n" +
                "Press OK to continue.", "Mod Manager Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (userAction == DialogResult.OK)
            {
                FileSystem.FileDelete(installerPath);
                foreach (ReleaseAsset ra in latestRelease.Assets)
                {
                    if (ra.Name == "ModManagerInstaller.exe")
                    {
                        try
                        {
                            await Downloader.downloadPath(ra.BrowserDownloadUrl, installerPath);
                        }
                        catch (Exception e)
                        {
                            Log.showError("Updater", e.Source, e.Message);
                        }
                        Process.Start("explorer", installerPath);
                        Environment.Exit(0);
                    }
                }
            }
            Environment.Exit(0);
        }

        public static async Task GetGithubVersion()
        {
            Release r = new Release() { };
            try
            {
                r = await ModManager.githubClient.Repository.Release.GetLatest("MatuxGG", "ModManager");
            }
            catch (Exception e)
            {
                Log.showError("Updater", e.Source, e.Message);
            }

            latestRelease = r;
            latestVersion = Version.Parse(r.TagName);
        }
    }
}