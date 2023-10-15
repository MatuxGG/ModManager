using ModManager6.Classes;

namespace ModManager6.Forms
{
    partial class Feedback
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FeedbackPanel = new System.Windows.Forms.Panel();
            this.FeedbackBottomPanel = new System.Windows.Forms.Panel();
            this.Star4 = new System.Windows.Forms.PictureBox();
            this.Star5 = new System.Windows.Forms.PictureBox();
            this.Star3 = new System.Windows.Forms.PictureBox();
            this.Star2 = new System.Windows.Forms.PictureBox();
            this.Star1 = new System.Windows.Forms.PictureBox();
            this.FeedbackText = new ModManager6.Objects.MMLabel();
            this.FeedbackTitle = new ModManager6.Objects.MMLabel();
            this.FeedbackPanel.SuspendLayout();
            this.FeedbackBottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Star4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star1)).BeginInit();
            this.SuspendLayout();
            // 
            // FeedbackPanel
            // 
            this.FeedbackPanel.BackColor = System.Drawing.SystemColors.ControlText;
            this.FeedbackPanel.Controls.Add(this.FeedbackBottomPanel);
            this.FeedbackPanel.Controls.Add(this.FeedbackText);
            this.FeedbackPanel.Controls.Add(this.FeedbackTitle);
            this.FeedbackPanel.Location = new System.Drawing.Point(1, 1);
            this.FeedbackPanel.Name = "FeedbackPanel";
            this.FeedbackPanel.Size = new System.Drawing.Size(798, 298);
            this.FeedbackPanel.TabIndex = 0;
            // 
            // FeedbackBottomPanel
            // 
            this.FeedbackBottomPanel.Controls.Add(this.Star4);
            this.FeedbackBottomPanel.Controls.Add(this.Star5);
            this.FeedbackBottomPanel.Controls.Add(this.Star3);
            this.FeedbackBottomPanel.Controls.Add(this.Star2);
            this.FeedbackBottomPanel.Controls.Add(this.Star1);
            this.FeedbackBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FeedbackBottomPanel.Location = new System.Drawing.Point(0, 198);
            this.FeedbackBottomPanel.Name = "FeedbackBottomPanel";
            this.FeedbackBottomPanel.Padding = new System.Windows.Forms.Padding(225, 0, 225, 30);
            this.FeedbackBottomPanel.Size = new System.Drawing.Size(798, 100);
            this.FeedbackBottomPanel.TabIndex = 2;
            // 
            // Star4
            // 
            this.Star4.BackgroundImage = global::ModManager6.Properties.Resources.favorite;
            this.Star4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Star4.Dock = System.Windows.Forms.DockStyle.Right;
            this.Star4.Location = new System.Drawing.Point(433, 0);
            this.Star4.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Star4.Name = "Star4";
            this.Star4.Size = new System.Drawing.Size(70, 70);
            this.Star4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Star4.TabIndex = 4;
            this.Star4.TabStop = false;
            this.Star4.Click += new System.EventHandler(this.Star4_Click);
            this.Star4.MouseEnter += new System.EventHandler(this.Star4_Hover);
            // 
            // Star5
            // 
            this.Star5.BackgroundImage = global::ModManager6.Properties.Resources.favorite;
            this.Star5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Star5.Dock = System.Windows.Forms.DockStyle.Right;
            this.Star5.Location = new System.Drawing.Point(503, 0);
            this.Star5.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Star5.Name = "Star5";
            this.Star5.Size = new System.Drawing.Size(70, 70);
            this.Star5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Star5.TabIndex = 3;
            this.Star5.TabStop = false;
            this.Star5.Click += new System.EventHandler(this.Star5_Click);
            this.Star5.MouseEnter += new System.EventHandler(this.Star5_Hover);
            // 
            // Star3
            // 
            this.Star3.BackgroundImage = global::ModManager6.Properties.Resources.favorite;
            this.Star3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Star3.Dock = System.Windows.Forms.DockStyle.Left;
            this.Star3.Location = new System.Drawing.Point(365, 0);
            this.Star3.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Star3.Name = "Star3";
            this.Star3.Size = new System.Drawing.Size(70, 70);
            this.Star3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Star3.TabIndex = 2;
            this.Star3.TabStop = false;
            this.Star3.Click += new System.EventHandler(this.Star3_Click);
            this.Star3.MouseEnter += new System.EventHandler(this.Star3_Hover);
            // 
            // Star2
            // 
            this.Star2.BackgroundImage = global::ModManager6.Properties.Resources.favorite;
            this.Star2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Star2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Star2.Location = new System.Drawing.Point(295, 0);
            this.Star2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Star2.Name = "Star2";
            this.Star2.Size = new System.Drawing.Size(70, 70);
            this.Star2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Star2.TabIndex = 1;
            this.Star2.TabStop = false;
            this.Star2.Click += new System.EventHandler(this.Star2_Click);
            this.Star2.MouseEnter += new System.EventHandler(this.Star2_Hover);
            // 
            // Star1
            // 
            this.Star1.BackgroundImage = global::ModManager6.Properties.Resources.favorite;
            this.Star1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Star1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Star1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Star1.Location = new System.Drawing.Point(225, 0);
            this.Star1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Star1.Name = "Star1";
            this.Star1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.Star1.Size = new System.Drawing.Size(70, 70);
            this.Star1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Star1.TabIndex = 0;
            this.Star1.TabStop = false;
            this.Star1.Click += new System.EventHandler(this.Star1_Click);
            this.Star1.MouseEnter += new System.EventHandler(this.Star1_Hover);
            // 
            // FeedbackText
            // 
            this.FeedbackText.Dock = System.Windows.Forms.DockStyle.Top;
            this.FeedbackText.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FeedbackText.Location = new System.Drawing.Point(0, 98);
            this.FeedbackText.Name = "FeedbackText";
            this.FeedbackText.Size = new System.Drawing.Size(798, 100);
            this.FeedbackText.TabIndex = 1;
            this.FeedbackText.Text = "How was your experience with the mod MODNAME ?";
            this.FeedbackText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FeedbackText.UseMnemonic = false;
            // 
            // FeedbackTitle
            // 
            this.FeedbackTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.FeedbackTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FeedbackTitle.Location = new System.Drawing.Point(0, 0);
            this.FeedbackTitle.Name = "FeedbackTitle";
            this.FeedbackTitle.Size = new System.Drawing.Size(798, 98);
            this.FeedbackTitle.TabIndex = 0;
            this.FeedbackTitle.Text = "Feeback";
            this.FeedbackTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FeedbackTitle.UseMnemonic = false;
            // 
            // Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 300);
            this.Controls.Add(this.FeedbackPanel);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Feedback";
            this.Text = "Feedback";
            this.FeedbackPanel.ResumeLayout(false);
            this.FeedbackBottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Star4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FeedbackPanel;
        private Objects.MMLabel FeedbackTitle;
        private Objects.MMLabel FeedbackText;
        private System.Windows.Forms.Panel FeedbackBottomPanel;
        private System.Windows.Forms.PictureBox Star1;
        private System.Windows.Forms.PictureBox Star4;
        private System.Windows.Forms.PictureBox Star5;
        private System.Windows.Forms.PictureBox Star3;
        private System.Windows.Forms.PictureBox Star2;
    }
}