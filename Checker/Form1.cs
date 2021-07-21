using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using ZeyadRemoteControl.Servers;

namespace Checker
{
    public partial class Form1 : Form
    {

    
        public Form1()
        {
            InitializeComponent();
            x.StartInfo = y;

        }

    
      

        ProcessStartInfo y = new ProcessStartInfo(Application.StartupPath + "/" + "RemoteReciver.exe");
        Process x = new Process();
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
              
                this.Visible = false;
                this.ShowInTaskbar = false;
                timer1.Start();
                x.Start();

            }
            catch
            {

                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                
                if (x.HasExited)
                {

                    x.Start();
                }
                if(!x.Responding)
                {
                    x.Kill();
                                    }
            }
            catch { }


           
            
                    }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
         
            e.Cancel = true;
            x.Kill();
            
        }
    }
}
