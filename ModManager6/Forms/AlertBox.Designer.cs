namespace ModManager6.Forms
{
    partial class AlertBox
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
            this.components = new System.ComponentModel.Container();
            this.alertBoxTimer = new System.Windows.Forms.Timer(this.components);
            this.AlertBoxLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // alertBoxTimer
            // 
            this.alertBoxTimer.Tick += new System.EventHandler(this.alertBoxTimer_Tick);
            // 
            // AlertBoxLabel
            // 
            this.AlertBoxLabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.AlertBoxLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AlertBoxLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AlertBoxLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AlertBoxLabel.Location = new System.Drawing.Point(1, 1);
            this.AlertBoxLabel.Margin = new System.Windows.Forms.Padding(10);
            this.AlertBoxLabel.Name = "AlertBoxLabel";
            this.AlertBoxLabel.Padding = new System.Windows.Forms.Padding(20);
            this.AlertBoxLabel.Size = new System.Drawing.Size(398, 98);
            this.AlertBoxLabel.TabIndex = 0;
            this.AlertBoxLabel.Text = "Message";
            this.AlertBoxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AlertBoxLabel.Click += new System.EventHandler(this.AlertBoxLabel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.AlertBoxLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 100);
            this.panel1.TabIndex = 1;
            // 
            // AlertBox
            // 
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(400, 100);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlertBox";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer alertBoxTimer;
        private System.Windows.Forms.Label AlertBoxLabel;
        private System.Windows.Forms.Panel panel1;
    }
}