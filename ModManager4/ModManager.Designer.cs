
namespace ModManager4
{
    partial class ModManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModManager));
            this.InitProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // InitProgressBar
            // 
            this.InitProgressBar.Location = new System.Drawing.Point(484, 569);
            this.InitProgressBar.Name = "InitProgressBar";
            this.InitProgressBar.Size = new System.Drawing.Size(313, 23);
            this.InitProgressBar.TabIndex = 0;
            // 
            // ModManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImage = global::ModManager4.Properties.Resources.titlefondbig;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.InitProgressBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ModManager";
            this.Text = "Mod Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar InitProgressBar;
    }
}

