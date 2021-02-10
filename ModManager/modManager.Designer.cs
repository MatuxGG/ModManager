namespace ModManager
{
    partial class ModManager
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void change(object sender, System.EventArgs e)
        {

        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModManager));
            this.valid = new System.Windows.Forms.Button();
            this.mod = new System.Windows.Forms.ComboBox();
            this.title = new System.Windows.Forms.Label();
            this.choose = new System.Windows.Forms.Label();
            this.credits = new System.Windows.Forms.LinkLabel();
            this.version = new System.Windows.Forms.Label();
            this.modTitle = new System.Windows.Forms.Label();
            this.modDescripiton = new System.Windows.Forms.Label();
            this.currentModTitle = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Label();
            this.separator2 = new System.Windows.Forms.Label();
            this.currentMod = new System.Windows.Forms.Label();
            this.loading = new System.Windows.Forms.Label();
            this.separator3 = new System.Windows.Forms.Label();
            this.directoryTitle = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.directorySelect = new System.Windows.Forms.Button();
            this.directoryPath = new System.Windows.Forms.Label();
            this.Play = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // valid
            // 
            this.valid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valid.Location = new System.Drawing.Point(41, 626);
            this.valid.Name = "valid";
            this.valid.Size = new System.Drawing.Size(140, 51);
            this.valid.TabIndex = 0;
            this.valid.Text = "Switch mod";
            this.valid.UseVisualStyleBackColor = true;
            // 
            // mod
            // 
            this.mod.Cursor = System.Windows.Forms.Cursors.Default;
            this.mod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mod.FormattingEnabled = true;
            this.mod.Location = new System.Drawing.Point(42, 369);
            this.mod.Name = "mod";
            this.mod.Size = new System.Drawing.Size(369, 33);
            this.mod.TabIndex = 2;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(186, 31);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(444, 76);
            this.title.TabIndex = 3;
            this.title.Text = "Mod Manager";
            this.title.Click += new System.EventHandler(this.label1_Click);
            // 
            // choose
            // 
            this.choose.AutoSize = true;
            this.choose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choose.Location = new System.Drawing.Point(37, 324);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(165, 25);
            this.choose.TabIndex = 4;
            this.choose.Text = "Choose a mod :";
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // credits
            // 
            this.credits.AutoSize = true;
            this.credits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credits.Location = new System.Drawing.Point(629, 639);
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(146, 25);
            this.credits.TabIndex = 6;
            this.credits.TabStop = true;
            this.credits.Text = "made by Matux";
            this.credits.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.Location = new System.Drawing.Point(463, 639);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(111, 25);
            this.version.TabIndex = 7;
            this.version.Text = "Version 1.0";
            // 
            // modTitle
            // 
            this.modTitle.AutoSize = true;
            this.modTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modTitle.Location = new System.Drawing.Point(37, 452);
            this.modTitle.Name = "modTitle";
            this.modTitle.Size = new System.Drawing.Size(102, 25);
            this.modTitle.TabIndex = 8;
            this.modTitle.Text = "Mod Title";
            // 
            // modDescripiton
            // 
            this.modDescripiton.AutoSize = true;
            this.modDescripiton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modDescripiton.Location = new System.Drawing.Point(37, 496);
            this.modDescripiton.Name = "modDescripiton";
            this.modDescripiton.Size = new System.Drawing.Size(153, 25);
            this.modDescripiton.TabIndex = 9;
            this.modDescripiton.Text = "Mod Description";
            // 
            // currentModTitle
            // 
            this.currentModTitle.AutoSize = true;
            this.currentModTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentModTitle.Location = new System.Drawing.Point(37, 256);
            this.currentModTitle.Name = "currentModTitle";
            this.currentModTitle.Size = new System.Drawing.Size(144, 25);
            this.currentModTitle.TabIndex = 10;
            this.currentModTitle.Text = "Current mod :";
            this.currentModTitle.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // separator
            // 
            this.separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator.Location = new System.Drawing.Point(42, 303);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(706, 2);
            this.separator.TabIndex = 11;
            this.separator.Click += new System.EventHandler(this.separator_Click);
            // 
            // separator2
            // 
            this.separator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator2.Location = new System.Drawing.Point(42, 430);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(706, 2);
            this.separator2.TabIndex = 12;
            this.separator2.Click += new System.EventHandler(this.separator2_Click);
            // 
            // currentMod
            // 
            this.currentMod.AutoSize = true;
            this.currentMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMod.Location = new System.Drawing.Point(207, 256);
            this.currentMod.Name = "currentMod";
            this.currentMod.Size = new System.Drawing.Size(94, 25);
            this.currentMod.TabIndex = 13;
            this.currentMod.Text = "Unknown";
            this.currentMod.Click += new System.EventHandler(this.label2_Click);
            // 
            // loading
            // 
            this.loading.AutoSize = true;
            this.loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading.Location = new System.Drawing.Point(449, 372);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(147, 25);
            this.loading.TabIndex = 14;
            this.loading.Text = "Progress status";
            this.loading.Click += new System.EventHandler(this.loading_Click);
            // 
            // separator3
            // 
            this.separator3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator3.Location = new System.Drawing.Point(42, 232);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(706, 2);
            this.separator3.TabIndex = 15;
            this.separator3.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // directoryTitle
            // 
            this.directoryTitle.AutoSize = true;
            this.directoryTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryTitle.Location = new System.Drawing.Point(37, 138);
            this.directoryTitle.Name = "directoryTitle";
            this.directoryTitle.Size = new System.Drawing.Size(214, 25);
            this.directoryTitle.TabIndex = 16;
            this.directoryTitle.Text = "Among Us directory :";
            // 
            // folderBrowser
            // 
            this.folderBrowser.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // directorySelect
            // 
            this.directorySelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directorySelect.Location = new System.Drawing.Point(285, 134);
            this.directorySelect.Name = "directorySelect";
            this.directorySelect.Size = new System.Drawing.Size(143, 32);
            this.directorySelect.TabIndex = 17;
            this.directorySelect.Text = "Select directory";
            this.directorySelect.UseVisualStyleBackColor = false;
            // 
            // directoryPath
            // 
            this.directoryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryPath.Location = new System.Drawing.Point(37, 184);
            this.directoryPath.Name = "directoryPath";
            this.directoryPath.Size = new System.Drawing.Size(711, 28);
            this.directoryPath.TabIndex = 18;
            this.directoryPath.Text = "/!\\ Among Us directory not found, please select a location /!\\ ";
            this.directoryPath.Click += new System.EventHandler(this.directoryPath_Click);
            // 
            // Play
            // 
            this.Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play.Location = new System.Drawing.Point(230, 626);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(157, 51);
            this.Play.TabIndex = 19;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 715);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.directoryPath);
            this.Controls.Add(this.directorySelect);
            this.Controls.Add(this.directoryTitle);
            this.Controls.Add(this.separator3);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.currentMod);
            this.Controls.Add(this.separator2);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.currentModTitle);
            this.Controls.Add(this.modDescripiton);
            this.Controls.Add(this.modTitle);
            this.Controls.Add(this.version);
            this.Controls.Add(this.credits);
            this.Controls.Add(this.choose);
            this.Controls.Add(this.title);
            this.Controls.Add(this.mod);
            this.Controls.Add(this.valid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModManager";
            this.Text = "Mod Manager";
            this.Load += new System.EventHandler(this.ModManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button valid;
        private System.Windows.Forms.ComboBox mod;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label choose;
        private System.Windows.Forms.LinkLabel credits;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label modTitle;
        private System.Windows.Forms.Label modDescripiton;
        private System.Windows.Forms.Label currentModTitle;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Label separator2;
        private System.Windows.Forms.Label currentMod;
        private System.Windows.Forms.Label loading;
        private System.Windows.Forms.Label separator3;
        private System.Windows.Forms.Label directoryTitle;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button directorySelect;
        private System.Windows.Forms.Label directoryPath;
        private System.Windows.Forms.Button Play;
    }
}

