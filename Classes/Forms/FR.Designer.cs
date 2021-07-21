namespace ZeyadRemoteControl.Forms
{
    partial class FR
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("PMingLiU-ExtB", 50.25F);
            this.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Label1.Location = new System.Drawing.Point(58, 86);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(143, 67);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Text";
            this.Label1.SizeChanged += new System.EventHandler(this.Label1_SizeChanged);
            // 
            // FR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FR";
            this.Text = "FR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FR_FormClosing);
            this.Load += new System.EventHandler(this.FR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label Label1;
    }
}