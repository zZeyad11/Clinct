namespace Sender
{
    partial class ConnectPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IPs_List = new System.Windows.Forms.ListBox();
            this.Lbl_Persent = new System.Windows.Forms.Label();
            this.lbl_Scan = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPs_List
            // 
            this.IPs_List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(93)))));
            this.IPs_List.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IPs_List.Dock = System.Windows.Forms.DockStyle.Top;
            this.IPs_List.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPs_List.ForeColor = System.Drawing.Color.Beige;
            this.IPs_List.FormattingEnabled = true;
            this.IPs_List.ItemHeight = 52;
            this.IPs_List.Location = new System.Drawing.Point(0, 0);
            this.IPs_List.Name = "IPs_List";
            this.IPs_List.Size = new System.Drawing.Size(813, 260);
            this.IPs_List.TabIndex = 5;
            this.IPs_List.TabStop = false;
            this.IPs_List.UseTabStops = false;
            this.IPs_List.SelectedIndexChanged += new System.EventHandler(this.IPs_List_SelectedIndexChanged);
            // 
            // Lbl_Persent
            // 
            this.Lbl_Persent.AutoSize = true;
            this.Lbl_Persent.Font = new System.Drawing.Font("Comic Sans MS", 25F, System.Drawing.FontStyle.Bold);
            this.Lbl_Persent.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Persent.Location = new System.Drawing.Point(671, 45);
            this.Lbl_Persent.Name = "Lbl_Persent";
            this.Lbl_Persent.Size = new System.Drawing.Size(69, 48);
            this.Lbl_Persent.TabIndex = 3;
            this.Lbl_Persent.Text = "0%";
            // 
            // lbl_Scan
            // 
            this.lbl_Scan.AutoSize = true;
            this.lbl_Scan.Font = new System.Drawing.Font("Comic Sans MS", 25F, System.Drawing.FontStyle.Bold);
            this.lbl_Scan.ForeColor = System.Drawing.Color.Black;
            this.lbl_Scan.Location = new System.Drawing.Point(167, 45);
            this.lbl_Scan.Name = "lbl_Scan";
            this.lbl_Scan.Size = new System.Drawing.Size(98, 48);
            this.lbl_Scan.TabIndex = 4;
            this.lbl_Scan.Text = "Scan";
            this.lbl_Scan.Click += new System.EventHandler(this.lbl_Scan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(93)))));
            this.panel1.Controls.Add(this.lbl_Scan);
            this.panel1.Controls.Add(this.Lbl_Persent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 124);
            this.panel1.TabIndex = 6;
            // 
            // ConnectPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(66)))), ((int)(((byte)(93)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.IPs_List);
            this.Name = "ConnectPanel";
            this.Size = new System.Drawing.Size(813, 390);
            this.Load += new System.EventHandler(this.ConnectPanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox IPs_List;
        private System.Windows.Forms.Label Lbl_Persent;
        private System.Windows.Forms.Label lbl_Scan;
        private System.Windows.Forms.Panel panel1;
    }
}
