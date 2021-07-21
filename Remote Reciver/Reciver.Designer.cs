namespace Remote_Reciver
{
    partial class Reciver
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
            this.Tcp_Reciver = new System.Windows.Forms.Timer(this.components);
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Tcp_Reciver
            // 
            this.Tcp_Reciver.Enabled = true;
            this.Tcp_Reciver.Interval = 1;
            this.Tcp_Reciver.Tick += new System.EventHandler(this.Tcp_Reciver_Tick);
            // 
            // Timer2
            // 
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // Reciver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Name = "Reciver";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Tcp_Reciver;
        private System.Windows.Forms.Timer Timer2;
    }
}

