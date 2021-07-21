using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sender
{
    public partial class Error : Form
    {
        public Error(string Msg)
        {
            InitializeComponent();
            label1.Text = Msg;
        }

        private void Error_Load(object sender, EventArgs e)
        {
           
            label1.SetBounds((this.ClientSize.Width - label1.Width) / 2, (this.ClientSize.Height - label1.Height) / 2, 0, 0, BoundsSpecified.Location);
            CountDown.Start();
        }

        private void CountDown_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
