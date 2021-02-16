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
            this.mainTitle = new System.Windows.Forms.Label();
            this.AmongUsDirectoryLabel = new System.Windows.Forms.Label();
            this.AmongUsDirectorySelection = new System.Windows.Forms.Button();
            this.AmongUsPathSelection = new System.Windows.Forms.TextBox();
            this.AmongUsSelectionPopup = new System.Windows.Forms.FolderBrowserDialog();
            this.AmongUsPathLabel = new System.Windows.Forms.Label();
            this.credits = new System.Windows.Forms.LinkLabel();
            this.VersionField = new System.Windows.Forms.Label();
            this.AmongUsDirSwitchButton = new System.Windows.Forms.Button();
            this.AmongUsDirSwitchLabel = new System.Windows.Forms.Label();
            this.OpenAmongUs = new System.Windows.Forms.Button();
            this.RemoveModsButton = new System.Windows.Forms.Button();
            this.PlayGameButton = new System.Windows.Forms.Button();
            this.ModsGroupbox = new System.Windows.Forms.GroupBox();
            this.ModsPanel = new System.Windows.Forms.Panel();
            this.AmongUsDirectoryConfirm = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.frFlag = new System.Windows.Forms.PictureBox();
            this.enFlag = new System.Windows.Forms.PictureBox();
            this.UpdateModsButton = new System.Windows.Forms.Button();
            this.WaitLabel = new System.Windows.Forms.Label();
            this.ModsGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTitle
            // 
            this.mainTitle.AutoSize = true;
            this.mainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.mainTitle.Location = new System.Drawing.Point(246, 28);
            this.mainTitle.Name = "mainTitle";
            this.mainTitle.Size = new System.Drawing.Size(529, 91);
            this.mainTitle.TabIndex = 3;
            this.mainTitle.Text = "Mod Manager";
            // 
            // AmongUsDirectoryLabel
            // 
            this.AmongUsDirectoryLabel.AutoSize = true;
            this.AmongUsDirectoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmongUsDirectoryLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AmongUsDirectoryLabel.Location = new System.Drawing.Point(304, 265);
            this.AmongUsDirectoryLabel.Name = "AmongUsDirectoryLabel";
            this.AmongUsDirectoryLabel.Size = new System.Drawing.Size(426, 29);
            this.AmongUsDirectoryLabel.TabIndex = 5;
            this.AmongUsDirectoryLabel.Text = "Please select your Among Us directory";
            // 
            // AmongUsDirectorySelection
            // 
            this.AmongUsDirectorySelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmongUsDirectorySelection.Location = new System.Drawing.Point(356, 340);
            this.AmongUsDirectorySelection.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.AmongUsDirectorySelection.Name = "AmongUsDirectorySelection";
            this.AmongUsDirectorySelection.Size = new System.Drawing.Size(302, 71);
            this.AmongUsDirectorySelection.TabIndex = 6;
            this.AmongUsDirectorySelection.Text = "Select directory";
            this.AmongUsDirectorySelection.UseVisualStyleBackColor = true;
            // 
            // AmongUsPathSelection
            // 
            this.AmongUsPathSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmongUsPathSelection.Location = new System.Drawing.Point(36, 605);
            this.AmongUsPathSelection.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.AmongUsPathSelection.Name = "AmongUsPathSelection";
            this.AmongUsPathSelection.Size = new System.Drawing.Size(974, 35);
            this.AmongUsPathSelection.TabIndex = 7;
            this.AmongUsPathSelection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AmongUsSelectionPopup
            // 
            this.AmongUsSelectionPopup.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.AmongUsSelectionPopup.SelectedPath = "C:\\";
            // 
            // AmongUsPathLabel
            // 
            this.AmongUsPathLabel.AutoSize = true;
            this.AmongUsPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmongUsPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AmongUsPathLabel.Location = new System.Drawing.Point(304, 529);
            this.AmongUsPathLabel.Name = "AmongUsPathLabel";
            this.AmongUsPathLabel.Size = new System.Drawing.Size(424, 29);
            this.AmongUsPathLabel.TabIndex = 8;
            this.AmongUsPathLabel.Text = "Or enter Among Us directory path here";
            // 
            // credits
            // 
            this.credits.AutoSize = true;
            this.credits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.credits.LinkColor = System.Drawing.Color.White;
            this.credits.Location = new System.Drawing.Point(832, 880);
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(176, 29);
            this.credits.TabIndex = 9;
            this.credits.TabStop = true;
            this.credits.Text = "Made By Matux";
            // 
            // VersionField
            // 
            this.VersionField.AutoSize = true;
            this.VersionField.BackColor = System.Drawing.SystemColors.ControlText;
            this.VersionField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionField.ForeColor = System.Drawing.Color.Lime;
            this.VersionField.Location = new System.Drawing.Point(604, 880);
            this.VersionField.Name = "VersionField";
            this.VersionField.Size = new System.Drawing.Size(187, 29);
            this.VersionField.TabIndex = 10;
            this.VersionField.Text = "Version X.X.X.X";
            // 
            // AmongUsDirSwitchButton
            // 
            this.AmongUsDirSwitchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmongUsDirSwitchButton.Location = new System.Drawing.Point(309, 162);
            this.AmongUsDirSwitchButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.AmongUsDirSwitchButton.Name = "AmongUsDirSwitchButton";
            this.AmongUsDirSwitchButton.Size = new System.Drawing.Size(134, 51);
            this.AmongUsDirSwitchButton.TabIndex = 11;
            this.AmongUsDirSwitchButton.Text = "Change";
            this.AmongUsDirSwitchButton.UseVisualStyleBackColor = true;
            // 
            // AmongUsDirSwitchLabel
            // 
            this.AmongUsDirSwitchLabel.AutoSize = true;
            this.AmongUsDirSwitchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmongUsDirSwitchLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AmongUsDirSwitchLabel.Location = new System.Drawing.Point(30, 171);
            this.AmongUsDirSwitchLabel.Name = "AmongUsDirSwitchLabel";
            this.AmongUsDirSwitchLabel.Size = new System.Drawing.Size(235, 29);
            this.AmongUsDirSwitchLabel.TabIndex = 12;
            this.AmongUsDirSwitchLabel.Text = "Among Us directory :";
            // 
            // OpenAmongUs
            // 
            this.OpenAmongUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenAmongUs.Location = new System.Drawing.Point(528, 162);
            this.OpenAmongUs.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.OpenAmongUs.Name = "OpenAmongUs";
            this.OpenAmongUs.Size = new System.Drawing.Size(129, 51);
            this.OpenAmongUs.TabIndex = 13;
            this.OpenAmongUs.Text = "Open";
            this.OpenAmongUs.UseVisualStyleBackColor = true;
            // 
            // RemoveModsButton
            // 
            this.RemoveModsButton.BackColor = System.Drawing.Color.Red;
            this.RemoveModsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveModsButton.Location = new System.Drawing.Point(36, 871);
            this.RemoveModsButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RemoveModsButton.Name = "RemoveModsButton";
            this.RemoveModsButton.Size = new System.Drawing.Size(296, 49);
            this.RemoveModsButton.TabIndex = 16;
            this.RemoveModsButton.Text = "Remove mods";
            this.RemoveModsButton.UseVisualStyleBackColor = false;
            // 
            // PlayGameButton
            // 
            this.PlayGameButton.BackColor = System.Drawing.Color.Lime;
            this.PlayGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayGameButton.Location = new System.Drawing.Point(386, 871);
            this.PlayGameButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PlayGameButton.Name = "PlayGameButton";
            this.PlayGameButton.Size = new System.Drawing.Size(158, 49);
            this.PlayGameButton.TabIndex = 17;
            this.PlayGameButton.Text = "Play";
            this.PlayGameButton.UseVisualStyleBackColor = false;
            // 
            // ModsGroupbox
            // 
            this.ModsGroupbox.Controls.Add(this.ModsPanel);
            this.ModsGroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModsGroupbox.ForeColor = System.Drawing.SystemColors.Control;
            this.ModsGroupbox.Location = new System.Drawing.Point(26, 220);
            this.ModsGroupbox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ModsGroupbox.Name = "ModsGroupbox";
            this.ModsGroupbox.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ModsGroupbox.Size = new System.Drawing.Size(994, 625);
            this.ModsGroupbox.TabIndex = 18;
            this.ModsGroupbox.TabStop = false;
            this.ModsGroupbox.Text = "Choose wanted mods :";
            // 
            // ModsPanel
            // 
            this.ModsPanel.AutoScroll = true;
            this.ModsPanel.Location = new System.Drawing.Point(9, 35);
            this.ModsPanel.Name = "ModsPanel";
            this.ModsPanel.Size = new System.Drawing.Size(975, 582);
            this.ModsPanel.TabIndex = 0;
            // 
            // AmongUsDirectoryConfirm
            // 
            this.AmongUsDirectoryConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmongUsDirectoryConfirm.Location = new System.Drawing.Point(356, 688);
            this.AmongUsDirectoryConfirm.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.AmongUsDirectoryConfirm.Name = "AmongUsDirectoryConfirm";
            this.AmongUsDirectoryConfirm.Size = new System.Drawing.Size(302, 71);
            this.AmongUsDirectoryConfirm.TabIndex = 19;
            this.AmongUsDirectoryConfirm.Text = "Confirm directory";
            this.AmongUsDirectoryConfirm.UseVisualStyleBackColor = true;
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(58, 28);
            this.logo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(117, 126);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 20;
            this.logo.TabStop = false;
            // 
            // frFlag
            // 
            this.frFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.frFlag.Image = ((System.Drawing.Image)(resources.GetObject("frFlag.Image")));
            this.frFlag.Location = new System.Drawing.Point(837, 57);
            this.frFlag.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.frFlag.Name = "frFlag";
            this.frFlag.Size = new System.Drawing.Size(70, 62);
            this.frFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.frFlag.TabIndex = 21;
            this.frFlag.TabStop = false;
            // 
            // enFlag
            // 
            this.enFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enFlag.Image = ((System.Drawing.Image)(resources.GetObject("enFlag.Image")));
            this.enFlag.Location = new System.Drawing.Point(928, 57);
            this.enFlag.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.enFlag.Name = "enFlag";
            this.enFlag.Size = new System.Drawing.Size(70, 62);
            this.enFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.enFlag.TabIndex = 22;
            this.enFlag.TabStop = false;
            // 
            // UpdateModsButton
            // 
            this.UpdateModsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateModsButton.Location = new System.Drawing.Point(801, 160);
            this.UpdateModsButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.UpdateModsButton.Name = "UpdateModsButton";
            this.UpdateModsButton.Size = new System.Drawing.Size(218, 51);
            this.UpdateModsButton.TabIndex = 23;
            this.UpdateModsButton.Text = "Update mods";
            this.UpdateModsButton.UseVisualStyleBackColor = true;
            // 
            // WaitLabel
            // 
            this.WaitLabel.AutoSize = true;
            this.WaitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WaitLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.WaitLabel.Location = new System.Drawing.Point(32, 880);
            this.WaitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WaitLabel.Name = "WaitLabel";
            this.WaitLabel.Size = new System.Drawing.Size(161, 29);
            this.WaitLabel.TabIndex = 24;
            this.WaitLabel.Text = "Please wait ...";
            // 
            // ModManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1047, 942);
            this.Controls.Add(this.WaitLabel);
            this.Controls.Add(this.UpdateModsButton);
            this.Controls.Add(this.enFlag);
            this.Controls.Add(this.frFlag);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.AmongUsDirectoryConfirm);
            this.Controls.Add(this.PlayGameButton);
            this.Controls.Add(this.RemoveModsButton);
            this.Controls.Add(this.OpenAmongUs);
            this.Controls.Add(this.AmongUsDirSwitchLabel);
            this.Controls.Add(this.AmongUsDirSwitchButton);
            this.Controls.Add(this.VersionField);
            this.Controls.Add(this.credits);
            this.Controls.Add(this.AmongUsPathLabel);
            this.Controls.Add(this.AmongUsPathSelection);
            this.Controls.Add(this.AmongUsDirectorySelection);
            this.Controls.Add(this.AmongUsDirectoryLabel);
            this.Controls.Add(this.mainTitle);
            this.Controls.Add(this.ModsGroupbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ModManager";
            this.Text = "Mod Manager";
            this.ModsGroupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mainTitle;
        private System.Windows.Forms.Label AmongUsDirectoryLabel;
        private System.Windows.Forms.Button AmongUsDirectorySelection;
        private System.Windows.Forms.TextBox AmongUsPathSelection;
        private System.Windows.Forms.FolderBrowserDialog AmongUsSelectionPopup;
        private System.Windows.Forms.Label AmongUsPathLabel;
        private System.Windows.Forms.LinkLabel credits;
        private System.Windows.Forms.Label VersionField;
        private System.Windows.Forms.Button AmongUsDirSwitchButton;
        private System.Windows.Forms.Label AmongUsDirSwitchLabel;
        private System.Windows.Forms.Button OpenAmongUs;
        private System.Windows.Forms.Button RemoveModsButton;
        private System.Windows.Forms.Button PlayGameButton;
        private System.Windows.Forms.GroupBox ModsGroupbox;
        private System.Windows.Forms.Button AmongUsDirectoryConfirm;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.PictureBox frFlag;
        private System.Windows.Forms.PictureBox enFlag;
        private System.Windows.Forms.Panel ModsPanel;
        private System.Windows.Forms.Button UpdateModsButton;
        private System.Windows.Forms.Label WaitLabel;
    }
}

