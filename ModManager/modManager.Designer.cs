using System.Windows.Forms;

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
            this.VersionField = new System.Windows.Forms.Label();
            this.AmongUsSelectionPopup = new System.Windows.Forms.FolderBrowserDialog();
            this.separator1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainTitle
            // 
            resources.ApplyResources(this.mainTitle, "mainTitle");
            this.mainTitle.BackColor = System.Drawing.Color.Transparent;
            this.mainTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.mainTitle.Name = "mainTitle";
            // 
            // VersionField
            // 
            resources.ApplyResources(this.VersionField, "VersionField");
            this.VersionField.BackColor = System.Drawing.SystemColors.ControlText;
            this.VersionField.ForeColor = System.Drawing.Color.Lime;
            this.VersionField.Name = "VersionField";
            // 
            // AmongUsSelectionPopup
            // 
            this.AmongUsSelectionPopup.RootFolder = System.Environment.SpecialFolder.MyComputer;
            resources.ApplyResources(this.AmongUsSelectionPopup, "AmongUsSelectionPopup");
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.SystemColors.Control;
            this.separator1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.separator1, "separator1");
            this.separator1.Name = "separator1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ModManager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.VersionField);
            this.Controls.Add(this.mainTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mainTitle;
        private System.Windows.Forms.FolderBrowserDialog AmongUsSelectionPopup;
        public System.Windows.Forms.Label VersionField;
        private Label separator1;
        private Label label1;
    }
}

