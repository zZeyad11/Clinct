using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeyadRemoteControl.Events.Args;
using ZeyadRemoteControl;
using ZeyadRemoteControl.Senders;
using ZeyadRemoteControl.Recivers;

namespace Sender.Forms
{

    public partial class ProcessesList : Form
    {
        public ProcessesList()
        {
            InitializeComponent();
            
        }

        public string IP="";
        ObjReciver reciver = new ObjReciver(7645);


        
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private static bool AreListsEqual(List<string> list1, List<string> list2)
        {
            var areListsEqual = true;

            if (list1.Count != list2.Count)
                return false;

            for (var i = 0; i < list1.Count; i++)
            {
                if (list2[i] != list1[i])
                {
                    areListsEqual = false;
                }
            }

            return areListsEqual;

        }
        private void ReciveaEvent(object sender, RecivedObjectEvent update)
        {
            
            Invoke(new Action(() =>
            {
              
                List<string> b = ((string)update.Obj).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> m = new List<string>();
                foreach (string n in listBox1.Items)
                {
                    m.Add(n);
                }
                if (!AreListsEqual(m, b))
                {
                    listBox1.Items.Clear();
                    foreach (var h in ((string)update.Obj).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (h != "")
                        {
                            listBox1.Items.Add(h.Split('|')[0]);
                        }
                    }
                }   
                
               

            }));
        }
        private void label2_Click(object sender, EventArgs e)
        {

            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch
            {

                
            }
        }

        private void Kill_Click(object sender, EventArgs e)
        {
            var ZSend = new MessageSender(IP, 7575);
            ZSend.Message = "W_Kill " + listBox1.Items[listBox1.SelectedIndex];
            ZSend.SendMessage();
            listBox1.Items.Remove(listBox1.Items[listBox1.SelectedIndex]);
        }

        #region MoveForm

        private bool mouseDown;
        private Point lastLocation;
        private void MovePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MovePanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void MovePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        #endregion

        private void ProcessesList_FormClosing(object sender, FormClosingEventArgs e)
        {
            reciver.Stop();
        }

        private void ProcessesList_Load(object sender, EventArgs e)
        {
            reciver.Start();
            reciver.Update += ReciveaEvent;
        }

    }
}
