using Bunifu;
using Bunifu.Framework;
using Bunifu.Framework.UI;
namespace AutoSetup
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Head = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Loction = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.ToTextBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.FromTextBox = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Hotspot = new System.Windows.Forms.Panel();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.WifiPass = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.WifiSSid = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.Main = new System.Windows.Forms.Panel();
            this.Install = new System.Windows.Forms.Button();
            this.Head.SuspendLayout();
            this.Loction.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Hotspot.SuspendLayout();
            this.Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Head
            // 
            this.Head.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(71)))));
            this.Head.Controls.Add(this.button2);
            this.Head.Controls.Add(this.button1);
            this.Head.Controls.Add(this.label2);
            this.Head.Controls.Add(this.label1);
            this.Head.Dock = System.Windows.Forms.DockStyle.Top;
            this.Head.Location = new System.Drawing.Point(0, 0);
            this.Head.Name = "Head";
            this.Head.Size = new System.Drawing.Size(608, 44);
            this.Head.TabIndex = 0;
            this.Head.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Head_MouseDown);
            this.Head.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Head_MouseMove);
            this.Head.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Head_MouseUp);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(119, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "Hotspot";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Loction";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU-ExtB", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(552, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "-";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(579, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Loction
            // 
            this.Loction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.Loction.Controls.Add(this.bunifuCustomLabel2);
            this.Loction.Controls.Add(this.button3);
            this.Loction.Controls.Add(this.bunifuCustomLabel1);
            this.Loction.Controls.Add(this.ToTextBox);
            this.Loction.Controls.Add(this.FromTextBox);
            this.Loction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Loction.Location = new System.Drawing.Point(0, 0);
            this.Loction.Name = "Loction";
            this.Loction.Size = new System.Drawing.Size(608, 252);
            this.Loction.TabIndex = 1;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Segoe Script", 10F);
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(23, 65);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(27, 22);
            this.bunifuCustomLabel2.TabIndex = 2;
            this.bunifuCustomLabel2.Text = "To";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(512, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 44);
            this.button3.TabIndex = 1;
            this.button3.Text = "Change";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe Script", 10F);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(21, 24);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(49, 22);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "From";
            // 
            // ToTextBox
            // 
            this.ToTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ToTextBox.Enabled = false;
            this.ToTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ToTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ToTextBox.HintForeColor = System.Drawing.Color.Empty;
            this.ToTextBox.HintText = "";
            this.ToTextBox.isPassword = false;
            this.ToTextBox.LineFocusedColor = System.Drawing.Color.Blue;
            this.ToTextBox.LineIdleColor = System.Drawing.Color.Gray;
            this.ToTextBox.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.ToTextBox.LineThickness = 1;
            this.ToTextBox.Location = new System.Drawing.Point(92, 50);
            this.ToTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(403, 41);
            this.ToTextBox.TabIndex = 1;
            this.ToTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // FromTextBox
            // 
            this.FromTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FromTextBox.Enabled = false;
            this.FromTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FromTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FromTextBox.HintForeColor = System.Drawing.Color.Empty;
            this.FromTextBox.HintText = "";
            this.FromTextBox.isPassword = false;
            this.FromTextBox.LineFocusedColor = System.Drawing.Color.Gray;
            this.FromTextBox.LineIdleColor = System.Drawing.Color.Gray;
            this.FromTextBox.LineMouseHoverColor = System.Drawing.Color.Gray;
            this.FromTextBox.LineThickness = 1;
            this.FromTextBox.Location = new System.Drawing.Point(92, 10);
            this.FromTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FromTextBox.Name = "FromTextBox";
            this.FromTextBox.Size = new System.Drawing.Size(495, 40);
            this.FromTextBox.TabIndex = 1;
            this.FromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(71)))));
            this.panel1.Controls.Add(this.Install);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 60);
            this.panel1.TabIndex = 2;
            // 
            // Hotspot
            // 
            this.Hotspot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.Hotspot.Controls.Add(this.bunifuFlatButton2);
            this.Hotspot.Controls.Add(this.bunifuCheckbox1);
            this.Hotspot.Controls.Add(this.bunifuCustomLabel3);
            this.Hotspot.Controls.Add(this.bunifuCustomLabel5);
            this.Hotspot.Controls.Add(this.bunifuCustomLabel4);
            this.Hotspot.Controls.Add(this.WifiPass);
            this.Hotspot.Controls.Add(this.WifiSSid);
            this.Hotspot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hotspot.Location = new System.Drawing.Point(0, 0);
            this.Hotspot.Name = "Hotspot";
            this.Hotspot.Size = new System.Drawing.Size(608, 252);
            this.Hotspot.TabIndex = 3;
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.ButtonText = "Show";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = null;
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 90D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(444, 128);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(45)))));
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.SteelBlue;
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(51, 26);
            this.bunifuFlatButton2.TabIndex = 0;
            this.bunifuFlatButton2.Text = "Show";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.MouseDown += new System.EventHandler(this.bunifuFlatButton2_MouseDown);
            this.bunifuFlatButton2.MouseUp += new System.EventHandler(this.bunifuFlatButton2_MouseUp);
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.Checked = false;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.bunifuCheckbox1.ForeColor = System.Drawing.Color.White;
            this.bunifuCheckbox1.Location = new System.Drawing.Point(32, 19);
            this.bunifuCheckbox1.Name = "bunifuCheckbox1";
            this.bunifuCheckbox1.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox1.TabIndex = 3;
            this.bunifuCheckbox1.OnChange += new System.EventHandler(this.bunifuCheckbox1_OnChange);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Segoe Script", 15F);
            this.bunifuCustomLabel3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(58, 128);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(115, 32);
            this.bunifuCustomLabel3.TabIndex = 2;
            this.bunifuCustomLabel3.Text = "Password";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Segoe Script", 15F);
            this.bunifuCustomLabel5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(58, 12);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(131, 32);
            this.bunifuCustomLabel5.TabIndex = 2;
            this.bunifuCustomLabel5.Text = "Use Hotspot";
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Segoe Script", 15F);
            this.bunifuCustomLabel4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(58, 71);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(128, 32);
            this.bunifuCustomLabel4.TabIndex = 2;
            this.bunifuCustomLabel4.Text = "Wifi (SSID)";
            // 
            // WifiPass
            // 
            this.WifiPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.WifiPass.Enabled = false;
            this.WifiPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.WifiPass.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.WifiPass.HintForeColor = System.Drawing.Color.Empty;
            this.WifiPass.HintText = "";
            this.WifiPass.isPassword = true;
            this.WifiPass.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.WifiPass.LineIdleColor = System.Drawing.Color.Gray;
            this.WifiPass.LineMouseHoverColor = System.Drawing.Color.Gray;
            this.WifiPass.LineThickness = 2;
            this.WifiPass.Location = new System.Drawing.Point(196, 114);
            this.WifiPass.Margin = new System.Windows.Forms.Padding(4);
            this.WifiPass.Name = "WifiPass";
            this.WifiPass.Size = new System.Drawing.Size(299, 43);
            this.WifiPass.TabIndex = 1;
            this.WifiPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // WifiSSid
            // 
            this.WifiSSid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.WifiSSid.Enabled = false;
            this.WifiSSid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.WifiSSid.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.WifiSSid.HintForeColor = System.Drawing.Color.Empty;
            this.WifiSSid.HintText = "";
            this.WifiSSid.isPassword = false;
            this.WifiSSid.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.WifiSSid.LineIdleColor = System.Drawing.Color.Gray;
            this.WifiSSid.LineMouseHoverColor = System.Drawing.Color.Gray;
            this.WifiSSid.LineThickness = 2;
            this.WifiSSid.Location = new System.Drawing.Point(196, 65);
            this.WifiSSid.Margin = new System.Windows.Forms.Padding(4);
            this.WifiSSid.Name = "WifiSSid";
            this.WifiSSid.Size = new System.Drawing.Size(299, 38);
            this.WifiSSid.TabIndex = 1;
            this.WifiSSid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Main
            // 
            this.Main.Controls.Add(this.Loction);
            this.Main.Controls.Add(this.Hotspot);
            this.Main.Dock = System.Windows.Forms.DockStyle.Top;
            this.Main.Location = new System.Drawing.Point(0, 44);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(608, 252);
            this.Main.TabIndex = 3;
            // 
            // Install
            // 
            this.Install.BackColor = System.Drawing.Color.Transparent;
            this.Install.FlatAppearance.BorderSize = 0;
            this.Install.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Install.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Install.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Install.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Install.ForeColor = System.Drawing.Color.White;
            this.Install.Location = new System.Drawing.Point(239, 6);
            this.Install.Name = "Install";
            this.Install.Size = new System.Drawing.Size(113, 44);
            this.Install.TabIndex = 1;
            this.Install.Text = "Install";
            this.Install.UseVisualStyleBackColor = false;
            this.Install.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 356);
            this.Controls.Add(this.Main);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Head);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "COPY";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Head.ResumeLayout(false);
            this.Head.PerformLayout();
            this.Loction.ResumeLayout(false);
            this.Loction.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Hotspot.ResumeLayout(false);
            this.Hotspot.PerformLayout();
            this.Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Head;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Loction;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private BunifuCustomLabel bunifuCustomLabel2;
        private BunifuCustomLabel bunifuCustomLabel1;
        private BunifuMaterialTextbox ToTextBox;
        private BunifuMaterialTextbox FromTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel Hotspot;
        private System.Windows.Forms.Panel Main;
        private BunifuCheckbox bunifuCheckbox1;
        private BunifuCustomLabel bunifuCustomLabel3;
        private BunifuCustomLabel bunifuCustomLabel5;
        private BunifuCustomLabel bunifuCustomLabel4;
        private BunifuMaterialTextbox WifiPass;
        private BunifuMaterialTextbox WifiSSid;
        private BunifuFlatButton bunifuFlatButton2;
        private System.Windows.Forms.Button Install;
    }
}

