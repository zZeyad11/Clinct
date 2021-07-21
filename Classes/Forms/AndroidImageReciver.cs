using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZeyadRemoteControl.Events.Args;
using ZeyadRemoteControl.Recivers;
using ZeyadRemoteControl.Senders;

namespace ZeyadRemoteControl.Forms
{
    partial class Image_Show
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(898, 453);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Image_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(898, 453);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Image_Show";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Image_Show";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Image_Show_FormClosing);
            this.Load += new System.EventHandler(this.Image_Show_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
    public partial class Image_Show : Form
    {


        protected string ConfigPath = AppDomain.CurrentDomain.BaseDirectory + @"/Config";
        ImageReciver Reciver = new ImageReciver(2015);
        public Image_Show()
        {
            InitializeComponent();
            Reciver.Update += Reciver_Finsh;
            Reciver.Once = true;

        }

        private void Reciver_Finsh(object sender, RecivedFinshed e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, RecivedFinshed>(Reciver_Finsh), sender, e);
                return;
            }
            pictureBox1.BackgroundImage = e.Image;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            ChangeDone(true);
        }

        private void ChangeDone(bool x)
        {
            string text = File.ReadAllText(ConfigPath);
            string Line5 = (File.ReadLines(ConfigPath).ElementAtOrDefault(4));
            text = text.Replace(Line5, "Done=" + x.ToString());
            File.WriteAllText(ConfigPath, text);
        }
        private void Image_Show_Load(object sender, EventArgs e)
        {
            Reciver.Start();
            this.Visible = false;
            timer1.Start();
            Cursor.Hide();
        }

        private void Image_Show_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reciver.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.BackgroundImage != null)
            {
                this.Visible = true;
                timer1.Stop();
            }
        }
    }
}
