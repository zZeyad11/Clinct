using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using ZeyadRemoteControl;
using MetroFramework.Controls;
using ZeyadRemoteControl.Senders;
using ZeyadRemoteControl.NetworkScaners;

namespace Sender
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            connectPanel1.SelectedIPClicked += ConnectPanel_SelectedIPClicked;
            connectPanel1.BringToFront();

            connectPanel1.BackColor = BackColor;
            imageReciver1.BackColor = BackColor;
            tools1.BackColor = BackColor;
        }
        #region FormSwitch
        private void Btn_Tool_Click(object sender, EventArgs e)
        {
            if (Lbl_Stauts.Text.Contains("Stauts: Connected"))
            {
                SetbuttonsColorDarkOrangeAndMeGreen(Btn_Tool);
                tools1.BringToFront();
                tools1.IP = IP;
                imageReciver1.StopReciving();
            }
            else
            {
                
                 Error form = new Error("Please Connect To Device First");
                 form.ShowDialog();
            }

        }

        private void Btn_Live_Click(object sender, EventArgs e)
        {
            if (Lbl_Stauts.Text.Contains("Stauts: Connected"))
            {
                MessageSender Sender = new MessageSender(this.IP,7575);
                Sender.Message = "pcshare";
                Sender.SendMessage();
                imageReciver1.BringToFront();
                imageReciver1.StartReciving();
                SetbuttonsColorDarkOrangeAndMeGreen(Btn_Live);

            }
            else
            {
                  Error form = new Error("Please Connect To Device First");
                  form.ShowDialog();
            }
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            SetbuttonsColorDarkOrangeAndMeGreen(Btn_Connect);
            connectPanel1.BringToFront();
            
            imageReciver1.StopReciving();

        }

        private void SetbuttonsColorDarkOrangeAndMeGreen(Button btn)
        {
            if(btn == Btn_Connect)
            {
                btn.ForeColor = Color.Chartreuse;
                Btn_Live.ForeColor = Color.DarkOrange;
                Btn_Tool.ForeColor = Color.DarkOrange;
            }
            else if(btn == Btn_Live)
            {
                btn.ForeColor = Color.Chartreuse;
                Btn_Connect.ForeColor = Color.DarkOrange;
                Btn_Tool.ForeColor = Color.DarkOrange;
            }
            else if (btn == Btn_Tool)
            {
                btn.ForeColor = Color.Chartreuse;
                Btn_Live.ForeColor = Color.DarkOrange;
                Btn_Connect.ForeColor = Color.DarkOrange;
            }
        }
        #endregion

        #region FormStaffuu 

        private void ConnectPanel_SelectedIPClicked(object sender, ConnectPanel.Selected IP)
        {
            Lbl_Stauts.Text = "Stauts: Connected";
            Lbl_Stauts.ForeColor = Color.Green;
            this.IP = IP.IP;
        }

        private bool mouseDown;
        private Point lastLocation;
       public string IP;
      
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            imageReciver1.StopReciving();
            Process.GetCurrentProcess().Kill();
        }
        private void Bt_Tool_Click(object sender, EventArgs e)
        {
            if (FastPortNetworkScaner.IsPortOpen(Ip_TextBox.Text, 7575))
            {
                Lbl_Stauts.Text = "Stauts: Connected";
                Lbl_Stauts.ForeColor = Color.Green;
                this.IP = Ip_TextBox.Text;
            }
            else
            {
                (new Error("That Port Isn't Opened")).ShowDialog();
            }
        }
        private void Ip_TextBox_MouseLeave(object sender, EventArgs e)
        {
            if (Ip_TextBox.Text == "" && !Ip_TextBox.Focused)
            {
                Ip_TextBox.Text = "Enter IP Manuel";
            }
        }

        private void Ip_TextBox_MouseHover(object sender, EventArgs e)
        {
            if (Ip_TextBox.Text == "Enter IP Manuel")
            {
                Ip_TextBox.Text = "";
            }
        }

        private void Logo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Thread.Sleep(200);
            Process.GetCurrentProcess().Kill();
        }
    }
}
