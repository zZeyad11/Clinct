using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net;
using ZeyadRemoteControl.Audio;
using ZeyadRemoteControl.Senders;
using ZeyadRemoteControl.Killers;
using ZeyadRemoteControl.Forms;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using ZeyadRemoteControl.Servers;
using System.ComponentModel;
using WindowsInput;
using System.Runtime.InteropServices;

namespace Remote_Reciver
{
    public partial class Reciver : Form
    {
        //Music

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        //Program

        protected string ConfigPath = AppDomain.CurrentDomain.BaseDirectory + @"/Config";
        string port = (File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + @"/Config").ElementAtOrDefault(3)).Split(char.Parse("="))[1];
        TcpListener Listener;
        TcpClient Client = new TcpClient();
        MachineName machineName = new MachineName(415);
        private void Do_Work(string x)
        {
            try
            {
             
                Process y = new Process();
                y.StartInfo.FileName = "Cmd";
                y.StartInfo.CreateNoWindow = true;
                y.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                if (x.ToLower().Contains("wsign"))
                {

                    System.Diagnostics.Process.Start("shutdown", "-l -f");


                }
                else if ((x.ToLower().Contains("wmute")))
                {
                    AudioManager.SetMasterVolumeMute(!AudioManager.GetMasterVolumeMute());
                }
                else if ((x.ToLower().Contains("wvd")))
                {
                    if (AudioManager.GetMasterVolumeMute())
                    {
                        AudioManager.SetMasterVolumeMute(!AudioManager.GetMasterVolumeMute());
                    }
                    AudioManager.SetMasterVolume(AudioManager.GetMasterVolume() - 5);
                }
                else if ((x.ToLower().Contains("wvu")))
                {
                    if (AudioManager.GetMasterVolumeMute())
                    {
                        AudioManager.SetMasterVolumeMute(!AudioManager.GetMasterVolumeMute());
                    }
                    AudioManager.SetMasterVolume(AudioManager.GetMasterVolume() + 2);
                }
                else if ((x.ToLower().ToString().Contains("/")))
                {
                    x = x.Remove(0, 1);
                    y.StartInfo.Arguments = ("/c " + x);
                    y.Start();
                }

                else if ((x.ToLower().First() == '>'))
                {
                    CloseOtherForms();
                    FR form;
                    form = new FR(false);
                    string z = x.Remove(0, 1);
                    form.timer1.Start();
                    form.Label1.Text = z;
                    form.Label1.Visible = true;
                    form.Text = z;
                    form.Text = z;
                    form.ShowDialog();
                }
                else if ((x.ToLower().Contains("l>")))
                {
                    CloseOtherForms();
                    FR form;
                    form = new FR(true);
                    string z = x.Remove(0, 2);
                    
                    form.Label1.Text = z;
                    form.Label1.Visible = true;
                    form.Text = z;
                    form.Text = z;
                    form.ShowDialog();
                }
                else if (x.ToLower().Contains("wsleep"))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "CMD.EXE";
                    process.StartInfo.Arguments = "/C rundll32.exe powrprof.dll, SetSuspendState 0, 1, 0";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Start();

                }
                else if (x.Contains("W_Kill "))
                {
                    try
                    {
                        var i = int.Parse(x.Replace("W_Kill ", ""));
                        var Process = System.Diagnostics.Process.GetProcesses().ToList().Find(a => a.Id == i);
                        Process.Kill();
                    }
                    catch
                    {

                    }

                }
                else if ((x.ToLower().Contains("wlock")))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "CMD.EXE";
                    process.StartInfo.Arguments = "/C rundll32.exe user32.dll, LockWorkStation";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Start();
                }
                else if ((x.ToLower().Contains("closeprogram")))
                {
                    SendKeys.Send("%{F4}");
                }
                else if (x.ToLower().Contains("killcpu"))
                {
                    CPUKiller Killer = new CPUKiller(1000000);
                    Killer.Start();
                }
                else if ((x.ToLower().Contains("im=>")))
                {
                    Image_Show formeq;
                    CloseOtherForms();
                    Thread.Sleep(500);
                    formeq = new Image_Show();
                    Tcp_Reciver.Stop();
                    Listener.Stop();
                    ChangeDone(false);
                    Timer2.Start();
                    formeq.Show();
                }
                else if (x.ToLower().Contains("getprocesseslist"))
                {
                    string ipt = IPAddress.Parse(((IPEndPoint)(Client.Client.RemoteEndPoint)).Address.ToString()).ToString();
                    ObjSender g = new ObjSender(ipt, 7645, null);
                    g.SendProcessList = true;
                    g.SendObject();
                }
                else if (x.ToLower().Contains("pcshare"))
                {
                    string ip = IPAddress.Parse(((IPEndPoint)(Client.Client.RemoteEndPoint)).Address.ToString()).ToString();
                    ShareScreen u = new ShareScreen(ip, 2001);
                    u.Device = ZeyadRemoteControl.Enums.Device.Pc;
                    u.Sharescreen();
                }
                else if (x.ToLower().Contains("androidshare"))
                {
                    string ip = IPAddress.Parse(((IPEndPoint)(Client.Client.RemoteEndPoint)).Address.ToString()).ToString();
                    ShareScreen u = new ShareScreen(ip, 2001);
                    u.Device = ZeyadRemoteControl.Enums.Device.Android;
                    u.Sharescreen();
                }
                else if (x.ToLower().Contains("c>"))
                {
                    CloseOtherForms();
                    CloseOtherForms();
                }
                else if ((x.Contains("PlayNext")))
                {

                    keybd_event(0xB0, 0, 1, IntPtr.Zero);
                }
                else if ((x.Contains("PlayPREV")))
                {
                    keybd_event(0xB1, 0, 1, IntPtr.Zero);
                }
                else if ((x.Contains("TogglePlay")))
                {
                    keybd_event(0xB3, 0, 1, IntPtr.Zero);
                }
            }

            catch { }



        }
        private void CloseOtherForms()
        {
            FormCollection myForms = System.Windows.Forms.Application.OpenForms;
            foreach (Form frmName in myForms)
            {
                if (frmName != this)
                {
                    frmName.Close();
                }
            }
        }
        public Reciver()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        }

        private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            try { Listener.Stop(); machineName.Stop(); CreateHotspot(false); } catch { }
                    }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShouldCreateWifi();
            machineName.Start();
            Listener = new TcpListener(IPAddress.Any, Convert.ToInt16(port));
            try
            {
                Listener.Start();
               
                   
            }
            catch { }
        }     

        private void ShouldCreateWifi()
        {
            bool Hotspot = bool.Parse((File.ReadLines(ConfigPath).ElementAtOrDefault(0)).Split(char.Parse("="))[1].ToLower());
            if (Hotspot)
            {

               
                CreateHotspot(true);
            }
        }

        private void Tcp_Reciver_Tick(object sender, EventArgs e)
        {
            try
            {
                Hide();
                StreamReader Reader;
                Reader = null;
                string sms = "";
                if (Listener.Pending() == true)
                {
                    Client = Listener.AcceptTcpClient();
                    Reader = new StreamReader(Client.GetStream());
                    while (Reader.Peek() > -1)
                    {
                        sms = sms + Convert.ToChar(Reader.Read()).ToString();
                    }
                }

                Do_Work(sms);
            }
            catch
            {
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            String Done = (File.ReadLines(ConfigPath).ElementAtOrDefault(4)).Split(char.Parse("="))[1].ToLower();
            var Yes = bool.Parse(Done);
            if (Yes)
            {
                Listener.Start();
                Tcp_Reciver.Start();
            }
        }

        private void ChangeDone(bool x)
        {
            string text = File.ReadAllText(ConfigPath);
            string Line5 = (File.ReadLines(ConfigPath).ElementAtOrDefault(4));
            text = text.Replace(Line5, "Done="+x.ToString());
            File.WriteAllText(ConfigPath, text);
        }
        private void CreateHotspot(bool status)
        {
            string ssid = (File.ReadLines(ConfigPath).ElementAtOrDefault(1)).Split(char.Parse("="))[1];
            string key = (File.ReadLines(ConfigPath).ElementAtOrDefault(2)).Split(char.Parse("="))[1];
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            Process process = Process.Start(processStartInfo);

            if (process != null)
            {
                if (status)
                {
                    process.StandardInput.WriteLine("netsh wlan set hostednetwork mode=allow ssid = " + ssid + " key = " + key);
                    process.StandardInput.WriteLine("netsh wlan start hosted network");
                    process.StandardInput.Close();
                }
                else
                {
                    process.StandardInput.WriteLine("netsh wlan stop hostednetwork");
                    process.StandardInput.Close();
                }
            }
        }

    }
}
