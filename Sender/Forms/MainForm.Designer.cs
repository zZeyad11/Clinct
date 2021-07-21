
namespace Sender
{
    partial class MainForm
    {

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Lbl_Stauts = new System.Windows.Forms.Label();
            this.Bt_Connect = new System.Windows.Forms.Button();
            this.Ip_TextBox = new System.Windows.Forms.TextBox();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.Btn_Live = new System.Windows.Forms.Button();
            this.Btn_Tool = new System.Windows.Forms.Button();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.HeadPanel = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Main = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.connectPanel1 = new Sender.ConnectPanel();
            this.imageReciver1 = new Sender.ImageReciver();
            this.tools1 = new Sender.Tools();
            this.LeftPanel.SuspendLayout();
            this.HeadPanel.SuspendLayout();
            this.Logo.SuspendLayout();
            this.Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Stauts
            // 
            this.Lbl_Stauts.AutoSize = true;
            this.Lbl_Stauts.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.Lbl_Stauts.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Stauts.Location = new System.Drawing.Point(232, 14);
            this.Lbl_Stauts.Name = "Lbl_Stauts";
            this.Lbl_Stauts.Size = new System.Drawing.Size(189, 23);
            this.Lbl_Stauts.TabIndex = 1;
            this.Lbl_Stauts.Text = "Status: Not Connected";
            // 
            // Bt_Connect
            // 
            this.Bt_Connect.FlatAppearance.BorderSize = 0;
            this.Bt_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Connect.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Connect.ForeColor = System.Drawing.Color.DarkOrange;
            this.Bt_Connect.Location = new System.Drawing.Point(747, 11);
            this.Bt_Connect.Name = "Bt_Connect";
            this.Bt_Connect.Size = new System.Drawing.Size(102, 41);
            this.Bt_Connect.TabIndex = 9;
            this.Bt_Connect.Text = "Connect";
            this.Bt_Connect.UseVisualStyleBackColor = true;
            this.Bt_Connect.Click += new System.EventHandler(this.Bt_Tool_Click);
            // 
            // Ip_TextBox
            // 
            this.Ip_TextBox.BackColor = System.Drawing.Color.LavenderBlush;
            this.Ip_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Ip_TextBox.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ip_TextBox.Location = new System.Drawing.Point(501, 11);
            this.Ip_TextBox.Name = "Ip_TextBox";
            this.Ip_TextBox.Size = new System.Drawing.Size(348, 38);
            this.Ip_TextBox.TabIndex = 5;
            this.Ip_TextBox.Text = "Enter IP Manuel";
            this.Ip_TextBox.MouseLeave += new System.EventHandler(this.Ip_TextBox_MouseLeave);
            this.Ip_TextBox.MouseHover += new System.EventHandler(this.Ip_TextBox_MouseHover);
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Connect.FlatAppearance.BorderSize = 0;
            this.Btn_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Connect.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Connect.ForeColor = System.Drawing.Color.Chartreuse;
            this.Btn_Connect.Location = new System.Drawing.Point(37, 82);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(124, 63);
            this.Btn_Connect.TabIndex = 7;
            this.Btn_Connect.Text = "Connect";
            this.Btn_Connect.UseVisualStyleBackColor = false;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // Btn_Live
            // 
            this.Btn_Live.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Live.FlatAppearance.BorderSize = 0;
            this.Btn_Live.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Live.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Live.ForeColor = System.Drawing.Color.DarkOrange;
            this.Btn_Live.Location = new System.Drawing.Point(39, 212);
            this.Btn_Live.Name = "Btn_Live";
            this.Btn_Live.Size = new System.Drawing.Size(122, 63);
            this.Btn_Live.TabIndex = 8;
            this.Btn_Live.Text = "Live View";
            this.Btn_Live.UseVisualStyleBackColor = false;
            this.Btn_Live.Click += new System.EventHandler(this.Btn_Live_Click);
            // 
            // Btn_Tool
            // 
            this.Btn_Tool.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Tool.FlatAppearance.BorderSize = 0;
            this.Btn_Tool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Tool.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Tool.ForeColor = System.Drawing.Color.DarkOrange;
            this.Btn_Tool.Location = new System.Drawing.Point(37, 349);
            this.Btn_Tool.Name = "Btn_Tool";
            this.Btn_Tool.Size = new System.Drawing.Size(122, 63);
            this.Btn_Tool.TabIndex = 9;
            this.Btn_Tool.Text = "Tools";
            this.Btn_Tool.UseVisualStyleBackColor = false;
            this.Btn_Tool.Click += new System.EventHandler(this.Btn_Tool_Click);
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(170)))), ((int)(((byte)(250)))));
            this.LeftPanel.Controls.Add(this.Btn_Live);
            this.LeftPanel.Controls.Add(this.Btn_Tool);
            this.LeftPanel.Controls.Add(this.Btn_Connect);
            this.LeftPanel.Location = new System.Drawing.Point(0, 46);
            this.LeftPanel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Padding = new System.Windows.Forms.Padding(10);
            this.LeftPanel.Size = new System.Drawing.Size(215, 495);
            this.LeftPanel.TabIndex = 5;
            // 
            // HeadPanel
            // 
            this.HeadPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(170)))), ((int)(((byte)(250)))));
            this.HeadPanel.Controls.Add(this.Logo);
            this.HeadPanel.Controls.Add(this.button1);
            this.HeadPanel.Controls.Add(this.Exit);
            this.HeadPanel.Controls.Add(this.Bt_Connect);
            this.HeadPanel.Controls.Add(this.Lbl_Stauts);
            this.HeadPanel.Controls.Add(this.Ip_TextBox);
            this.HeadPanel.Location = new System.Drawing.Point(0, -4);
            this.HeadPanel.Name = "HeadPanel";
            this.HeadPanel.Size = new System.Drawing.Size(1100, 52);
            this.HeadPanel.TabIndex = 10;
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(170)))), ((int)(((byte)(250)))));
            this.Logo.Controls.Add(this.label1);
            this.Logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(215, 52);
            this.Logo.TabIndex = 10;
            this.Logo.Paint += new System.Windows.Forms.PaintEventHandler(this.Logo_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(77, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Z";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkOrange;
            this.button1.Location = new System.Drawing.Point(1021, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 49);
            this.button1.TabIndex = 9;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Exit
            // 
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.DarkOrange;
            this.Exit.Location = new System.Drawing.Point(939, 3);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(76, 49);
            this.Exit.TabIndex = 9;
            this.Exit.Text = "Min";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Main
            // 
            this.Main.Controls.Add(this.connectPanel1);
            this.Main.Controls.Add(this.imageReciver1);
            this.Main.Controls.Add(this.tools1);
            this.Main.Location = new System.Drawing.Point(211, 46);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(889, 495);
            this.Main.TabIndex = 11;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 50;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.HeadPanel;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.Logo;
            this.bunifuDragControl2.Vertical = true;
            // 
            // connectPanel1
            // 
            this.connectPanel1.AutoSize = true;
            this.connectPanel1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.connectPanel1.BackColor = System.Drawing.Color.White;
            this.connectPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectPanel1.Location = new System.Drawing.Point(0, 0);
            this.connectPanel1.Name = "connectPanel1";
            this.connectPanel1.Size = new System.Drawing.Size(889, 495);
            this.connectPanel1.TabIndex = 0;
            // 
            // imageReciver1
            // 
            this.imageReciver1.BackColor = this.BackColor;
            this.imageReciver1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageReciver1.Location = new System.Drawing.Point(0, 0);
            this.imageReciver1.Name = "imageReciver1";
            this.imageReciver1.Size = new System.Drawing.Size(889, 495);
            this.imageReciver1.TabIndex = 3;
            // 
            // tools1
            // 
            this.tools1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(46)))), ((int)(((byte)(55)))));
            this.tools1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tools1.Location = new System.Drawing.Point(0, 0);
            this.tools1.Name = "tools1";
            this.tools1.Size = new System.Drawing.Size(889, 495);
            this.tools1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(170)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1100, 542);
            this.Controls.Add(this.HeadPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.Main);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ForeColor = System.Drawing.Color.Snow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(17, 60, 17, 19);
            this.Text = "Sender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.LeftPanel.ResumeLayout(false);
            this.HeadPanel.ResumeLayout(false);
            this.HeadPanel.PerformLayout();
            this.Logo.ResumeLayout(false);
            this.Logo.PerformLayout();
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #region Windows Form Designer generated code

        #endregion
        private System.Windows.Forms.Label Lbl_Stauts;
        private Tools tools1;
        private ImageReciver imageReciver1;
        private ConnectPanel connectPanel1;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.Button Btn_Live;
        private System.Windows.Forms.Button Btn_Tool;
        private System.Windows.Forms.TextBox Ip_TextBox;
        private System.Windows.Forms.Button Bt_Connect;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel HeadPanel;
        private System.Windows.Forms.Panel Logo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Main;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Exit;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.ComponentModel.IContainer components;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
    }
}

