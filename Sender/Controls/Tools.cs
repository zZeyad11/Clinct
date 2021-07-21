using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeyadRemoteControl;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Sender.Forms;
using ZeyadRemoteControl.Senders;

namespace Sender
{
    public partial class Tools : UserControl
    {
        public Tools()
        {

            InitializeComponent();
        }
        MessageSender ZSend;
        static int port = 7575;
        public string IP = "";


        private void Btn_Shutdown_Click(object sender, EventArgs e)
        {
            ZSend = new MessageSender(IP, port);
            ZSend.Message = "/shutdown -s -t 1";

            ZSend.SendMessage();

        }

        private void Btn_SentImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = Application.StartupPath;
            openFileDialog.ShowDialog();
            if (!openFileDialog.FileName.Equals(""))
            {
                var image = File.ReadAllBytes(openFileDialog.FileName);
                ZSend = new MessageSender(IP, port);
                ZSend.Image = image;

                ZSend.SendImage();

            }

        }


        private void Btn_VD_Click(object sender, EventArgs e)
        {
            ZSend = new MessageSender(IP, port);
            ZSend.Message = "wvd";

            ZSend.SendMessage();
        }

        private void Btn_Vu_Click(object sender, EventArgs e)
        {
            ZSend = new MessageSender(IP, port);
            ZSend.Message = "wvu";
            ZSend.SendMessage();

        }

        private void btn_mute_Click(object sender, EventArgs e)
        {
            ZSend = new MessageSender(IP, port);
            ZSend.Message = "wmute";
            ZSend.SendMessage();


        }

        private void Btn_SendMsg_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ZSend = new MessageSender(IP, port);
                ZSend.Message = "/" + textBox1.Text; ;
                ZSend.SendMessage();
                textBox1.Visible = false;
            }
        }

        private void btn_lock_Click(object sender, EventArgs e)
        {
            ZSend = new MessageSender(IP, port);
            ZSend.Message = "wlock";
            ZSend.SendMessage();

        }

        private void btn_sleep_Click(object sender, EventArgs e)
        {
            ZSend = new MessageSender(IP, port);
            ZSend.Message = "wsleep";
            ZSend.SendMessage();


        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            ZSend = new MessageSender(IP, port);
            ZSend.Message = "closeprogram";
            ZSend.SendMessage();


        }
        private void Btn_Processes_Click(object sender, EventArgs e)
        {
            ZSend = new MessageSender(IP, port);
            ZSend.Message = "GetProcessesList";
            ZSend.SendMessage();
            ProcessesList A = new ProcessesList();
            A.IP = this.IP;
            A.ShowDialog();



        }




    }

}
