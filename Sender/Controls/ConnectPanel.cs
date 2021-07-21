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
using ZeyadRemoteControl.Events.Args;
using ZeyadRemoteControl.NetworkScaners;

namespace Sender
{
    public partial class ConnectPanel : UserControl
    {
        public ConnectPanel()
        {
            InitializeComponent();
           
        }
        public string IP;
        List<string> IPS = new List<string>();

        #region Events
        public delegate void SelectedIP(object sender, Selected IP);
        public class Selected : EventArgs
        {
            public string IP;
        }

        public event SelectedIP SelectedIPClicked;
        private void NetworkScaner_FinshedScan(object sender, FinshedScaning e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, FinshedScaning>(NetworkScaner_FinshedScan), sender, e);
                return;
            }
            lbl_Scan.Text = "Scan";
            lbl_Scan.Enabled = true;
            if (IPs_List.Items.Count.Equals(0))
            {
                IPs_List.Items.Add("No Device Was Found");
            }

        }
        private void NetworkScaner_Updator(object sender, FastScanUpdateEvent update)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, FastScanUpdateEvent>(NetworkScaner_Updator), sender, update);
                return;
            }

            

            Lbl_Persent.Text = update.Persent.ToString() + "%";
            if (lbl_Scan.Text.Equals("Scaning"))
            {
                lbl_Scan.Text = "Scaning.";
            }
            else if (lbl_Scan.Text.Equals("Scaning."))
            {
                lbl_Scan.Text = "Scaning..";
            }
            else if (lbl_Scan.Text.Equals("Scaning.."))
            {
                lbl_Scan.Text = "Scaning...";
            }
            else if (lbl_Scan.Text.Equals("Scaning..."))
            {
                lbl_Scan.Text = "Scaning";
            }
        }
        private void networkScaner_FoundIP(object sender, FastScanNewIpFoundEvent IP)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, ZeyadRemoteControl.Events.Args.FastScanNewIpFoundEvent>(networkScaner_FoundIP), sender, IP);
                return;
            }
            if (!IPs_List.Items.Contains(FastPortNetworkScaner.GetMachineName(IP.IP))&& !IPS.Contains(IP.IP))
                {
                IPs_List.Items.Add(FastPortNetworkScaner.GetMachineName(IP.IP));
                IPS.Add(IP.IP);
            }
            if (IPs_List.Items.Contains("No Device Was Found"))
            {
                IPs_List.Items.Remove("No Device Was Found");
            }
        }
        #endregion

        private void lbl_Scan_Click(object sender, EventArgs e)
        {
            IPs_List.Items.Clear();
            if (IPs_List.Items.Count.Equals(0))
            {
                IPs_List.Items.Add("No Device Was Found");
            }
            lbl_Scan.Text = "Scaning";
            Lbl_Persent.Text = "0%";
            lbl_Scan.Enabled = false;
            FastPortNetworkScaner networkScaner = new FastPortNetworkScaner(132,7575);
            networkScaner.RunScan();
            networkScaner.NewIpFound += networkScaner_FoundIP;
            networkScaner.Update += NetworkScaner_Updator;
            networkScaner.Finshed += NetworkScaner_FinshedScan;

        }   

        private void IPs_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IPs_List.Items[IPs_List.SelectedIndex].Equals("No Device Was Found"))
                {
                    IP = (IPS[IPs_List.SelectedIndex].ToString());
                    Selected a = new Selected();
                    a.IP = IP;
                    SelectedIPClicked(this, a);
                }
            }
            catch (Exception)
            {


            }
        }

        private void ConnectPanel_Load(object sender, EventArgs e)
        {
            IPs_List.BackColor = BackColor;
            panel1.BackColor = BackColor;
        }
    }
}
