using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeyadRemoteControl.Senders;
using ZeyadRemoteControl.Events.Args;

namespace Sender
{
    public partial class ImageReciver : UserControl
    {
        ZeyadRemoteControl.Recivers.ImageReciver reciver;
        public ImageReciver()
        {
            InitializeComponent();
            

            
        }

        public void StopReciving()
        {
            try
            {
                reciver.Stop();
            }
            catch { }

        }

        public void StartReciving()
        {
            try
            {

                reciver = new ZeyadRemoteControl.Recivers.ImageReciver(2001);
                reciver.Update += Reciver_Update;
                reciver.Start();
            }
            catch (Exception)
            {

              
            }
        }

        private void Reciver_Update(object sender, RecivedFinshed e)
        {
            if (e.Image != null)
            {
                pictureBox1.BackgroundImage = e.Image;
            }
           
        }
    }
}
