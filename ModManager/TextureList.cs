using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace ModManager
{
    public class TextureList
    {
        public string url;
        public string path;
        public List<Texture> textures;
        public ModManager modManager;

        public TextureList(string url, string path, ModManager modManager)
        {
            this.url = url;
            this.path = path;
            this.modManager = modManager;
            this.load();
        }

        public void load()
        {
            // Download remote files.zip
            using (var client = new WebClient())
            {
                client.DownloadFile(this.url+"/textures.json", this.path);
            }
            string json = System.IO.File.ReadAllText(this.path);
            this.textures = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Texture>>(json);
            File.Delete(this.path);
        }

        public void show()
        {
            ComboBox TextureBox = (ComboBox)this.modManager.pagelist.get("Settings").getControl("TextureBox");
            TextureBox.Items.Clear();
            TextureBox.Items.Add("None");
            foreach (Texture item in this.textures)
            {
                // Affichage Mod

                TextureBox.Items.Add(item.name);
            }
            if (this.modManager.config.texture == null)
            {
                this.modManager.config.texture = "None";
            }
            TextureBox.SelectedItem = this.modManager.config.texture;

            //this.changeModsForCategory();

        }

        public void changeTexture(object sender, EventArgs e)
        {
            ComboBox changedBox = ((ComboBox)sender);
            string name = changedBox.SelectedItem.ToString();

            if (this.modManager.config.texture != name)
            {

                if (System.Diagnostics.Process.GetProcessesByName("Among Us").Length > 0)
                {
                    MessageBox.Show("Close Among Us to install this texture pack", "Can't install texture pack", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    changedBox.SelectedItem = this.modManager.config.texture;
                    return;
                }

                Label waitLabel =  (Label)this.modManager.pagelist.get("Settings").getControl("TextureWaitLabel");
                waitLabel.Text = "Please wait ...";
                if (name == "None")
                {
                    this.cancelInstall();
                    this.modManager.config.texture = "None";
                    this.modManager.config.update();
                } else
                {
                    this.install(this.getTextureByName(name));
                    this.modManager.config.texture = name;
                    this.modManager.config.update();
                }
                waitLabel.Text = "";
                MessageBox.Show("This texture pack has been installed !", "Texture pack installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Texture getTextureByName(string name)
        {
            foreach (Texture t in this.textures)
            {
                if (t.name == name)
                {
                    return t;
                }
            }
            return null;
        }

        public void install(Texture texture) {
            DirectoryInfo backup = new DirectoryInfo(this.modManager.config.amongUsPath + "\\Among Us_Data.save");
            if (!backup.Exists)
            {
                this.modManager.utils.DirectoryCopy(this.modManager.config.amongUsPath + "\\Among Us_Data", this.modManager.config.amongUsPath + "\\Among Us_Data.save", true);
            }

            this.modManager.utils.DirectoryDelete(this.modManager.config.amongUsPath + "\\Among Us_Data");
            this.modManager.utils.DirectoryCopy(this.modManager.config.amongUsPath + "\\Among Us_Data.save", this.modManager.config.amongUsPath + "\\Among Us_Data", true);

            string tempPath = Path.GetTempPath() + "\\ModManager";

            this.modManager.utils.FileDelete(tempPath + "\\" + texture.id + ".zip");
            this.modManager.utils.DirectoryDelete(tempPath + "\\" + texture.id);
            try {
                using (var client = new WebClient())
                {
                    client.DownloadFile(this.url+"/"+texture.id+".zip", tempPath+"\\"+texture.id+".zip");
                }
            }
            catch
            {
                MessageBox.Show("Can't reach Mod Manager server.\nPlease verify your internet connection and try again !", "Mod Manager server unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            ZipFile.ExtractToDirectory(tempPath + "\\" + texture.id + ".zip", tempPath);
            this.modManager.utils.DirectoryCopy(tempPath + "\\" + texture.id, this.modManager.config.amongUsPath+"\\Among Us_Data", true);
        }

        public void cancelInstall()
        {
            this.modManager.utils.DirectoryDelete(this.modManager.config.amongUsPath + "\\Among Us_Data");
            this.modManager.utils.DirectoryCopy(this.modManager.config.amongUsPath + "\\Among Us_Data.save", this.modManager.config.amongUsPath + "\\Among Us_Data", true);
            this.modManager.utils.DirectoryDelete(this.modManager.config.amongUsPath + "\\Among Us_Data.save");
        }
    }
}