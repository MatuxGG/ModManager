﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager5.Classes
{
    public static class DownloadWorker
    {
        public static ModManager thisModManager;
        public static Boolean finished;
        public static string thisSentence;

        public static void load(ModManager modManager)
        {
            thisModManager = modManager;
        }

        public static void download(string path, string destPath, string sentence)
        {
            finished = false;
            thisSentence = sentence;
            thisModManager.Invoke((MethodInvoker)delegate
            {
                if (!ModManager.silent)
                {
                    ModManagerUI.StatusLabel.Text = Translator.get(thisSentence).Replace("PERCENT", "0");
                }
            });
            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(path), destPath);
            while (finished == false)
            {

            }
        }

        private static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            thisModManager.Invoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                if (!ModManager.silent)
                {
                    string text = Translator.get(thisSentence).Replace("PERCENT", ((int)percentage).ToString());
                    if (ModManagerUI.StatusLabel.Text != text)
                    {
                        ModManagerUI.StatusLabel.Text = text;
                    }
                }
            });
        }
        private static void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            thisModManager.Invoke((MethodInvoker)delegate {
                if (!ModManager.silent)
                {
                    ModManagerUI.StatusLabel.Text = Translator.get(thisSentence).Replace("PERCENT", "100");
                }
                finished = true;
            });
        }
    }
}