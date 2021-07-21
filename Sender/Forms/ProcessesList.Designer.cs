namespace Sender.Forms
{
    partial class ProcessesList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessesList));
            this.MovePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Kill = new Bunifu.Framework.UI.BunifuThinButton2();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.MovePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MovePanel
            // 
            this.MovePanel.BackColor = System.Drawing.Color.Teal;
            this.MovePanel.Controls.Add(this.label3);
            this.MovePanel.Controls.Add(this.label2);
            this.MovePanel.Controls.Add(this.label1);
            this.MovePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MovePanel.Location = new System.Drawing.Point(0, 0);
            this.MovePanel.Name = "MovePanel";
            this.MovePanel.Size = new System.Drawing.Size(361, 33);
            this.MovePanel.TabIndex = 0;
            this.MovePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovePanel_MouseDown);
            this.MovePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovePanel_MouseMove);
            this.MovePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovePanel_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Opened Windows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "-";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(334, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(57)))));
            this.panel2.Controls.Add(this.Kill);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 383);
            this.panel2.TabIndex = 1;
            // 
            // Kill
            // 
            this.Kill.ActiveBorderThickness = 1;
            this.Kill.ActiveCornerRadius = 20;
            this.Kill.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.Kill.ActiveForecolor = System.Drawing.Color.White;
            this.Kill.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.Kill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(57)))));
            this.Kill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Kill.BackgroundImage")));
            this.Kill.ButtonText = "Kill";
            this.Kill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Kill.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Kill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kill.ForeColor = System.Drawing.Color.SeaGreen;
            this.Kill.IdleBorderThickness = 1;
            this.Kill.IdleCornerRadius = 20;
            this.Kill.IdleFillColor = System.Drawing.Color.White;
            this.Kill.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.Kill.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.Kill.Location = new System.Drawing.Point(0, 338);
            this.Kill.Margin = new System.Windows.Forms.Padding(5);
            this.Kill.Name = "Kill";
            this.Kill.Size = new System.Drawing.Size(361, 45);
            this.Kill.TabIndex = 0;
            this.Kill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Kill.Click += new System.EventHandler(this.Kill_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(57)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 33;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(361, 383);
            this.listBox1.TabIndex = 2;
            // 
            // ProcessesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(361, 416);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MovePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProcessesList";
            this.Text = "ProcessesList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcessesList_FormClosing);
            this.Load += new System.EventHandler(this.ProcessesList_Load);
            this.MovePanel.ResumeLayout(false);
            this.MovePanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MovePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuThinButton2 Kill;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
    }
}