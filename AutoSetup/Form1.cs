using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using ZeyadRemoteControl.Servers;

namespace AutoSetup
{
    public partial class Form1 : Form
    {
       private Point mouseDownPoint = Point.Empty;
        public Form1()
        {
            InitializeComponent();
            FromTextBox.Text =  Environment.CurrentDirectory + @"\Program";
            ToTextBox.Text = @"C:\ProgramData\Reciver\";
            WifiPass.isPassword = true;
            WifiPass.ForeColor = Color.WhiteSmoke;
            WifiSSid.ForeColor = Color.WhiteSmoke;
        }

        void killprocess(string proname)
        {
            try
            {
                var chromeDriverProcesses = Process.GetProcesses().
                                     Where(pr => pr.ProcessName == proname);

                foreach (var process in chromeDriverProcesses)
                {
                    process.Kill();
                }
            }
            catch { }

        }
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Head_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void Head_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint.IsEmpty)
                return;
            var f = this;
            f.Location = new Point(f.Location.X + (e.X - mouseDownPoint.X), f.Location.Y + (e.Y - mouseDownPoint.Y));
        }

        private void Head_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPoint = Point.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = @"C:\ProgramData\Reciver\";
                this.TopMost = true;
                DialogResult result = fbd.ShowDialog();
                

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    ToTextBox.Text = fbd.SelectedPath + @"\Reciver";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loction.BringToFront();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Hotspot.BringToFront();
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked) { WifiSSid.Enabled = true; WifiPass.Enabled = true; }
            if (!bunifuCheckbox1.Checked) { WifiSSid.Enabled = false; WifiPass.Enabled = false; }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            var from = FromTextBox.Text;
            var to = ToTextBox.Text;
            try
            {
                killprocess("ClientService");
                killprocess("RemoteReciver");

                // If directory does not exist, don't even try 
                try
                {
                    if (Directory.Exists(to))
                    {
                        foreach (var i in Directory.GetFiles(to)) { System.IO.File.Delete(i); }
                        try { Directory.Delete(to); } catch { }
                        Directory.CreateDirectory(to);

                    }
                }
                catch { }
                Copy(from, to);
                SetConfigFile(to + "/Config");
                string program = to;
                if (program[program.Length - 1] == char.Parse(@"\"))
                    {

                    program +=@"ClientService.exe";
                }
                else
                {
                    program += @"\ClientService.exe";
                }

                DirectoryInfo di = new DirectoryInfo(to);
                if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    di.Attributes |= FileAttributes.Hidden;
                }
                CreateAutoStartup(program, "Reciver");
                Thread.Sleep(500);
                Process.Start(program);
                this.Dispose();
            }
        catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        private void SetConfigFile(string v)
        {
            var Config = "";
            Config += "Hotspot=" + bunifuCheckbox1.Checked + Environment.NewLine;
            Config += "Ssid=" + WifiSSid.Text + Environment.NewLine;
            Config += "Password=" + WifiPass.Text + Environment.NewLine;
            Config += "Port=7575" + Environment.NewLine;
            Config += "Done=True";
            System.IO.File.WriteAllText(v,Config);
            Task.Delay(1000);
        }

        private void bunifuFlatButton2_MouseDown(object sender, EventArgs e)
        {
            WifiPass.isPassword = false;
        }

        private void bunifuFlatButton2_MouseUp(object sender, EventArgs e)
        {
            WifiPass.isPassword = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void CreateAutoStartup(string ExePath,string Name)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue(Name, ExePath);
        }
    }
}
