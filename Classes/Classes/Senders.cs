using System;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Management;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using ZeyadRemoteControl.Enums;

namespace ZeyadRemoteControl.Senders
{



    public class MessageSender
    {
        string IP;
        int Port;
        Thread msgsender;
        Thread imgsender;
        public string Message { get; set; }
        public byte[] Image { get; set; }
        public void SendMessage()
        {

            if (Message != "")
            {
                msgsender = new Thread(sendobj);
                msgsender.Start();
            }
        }
        public void SendImage()
        {
            if (Image != null)
            {
                imgsender = new Thread(Sentimageobj);
                imgsender.Start();
            }
        }
        public MessageSender(string ip, int port) // Get IP , Port
        {
            this.IP = ip;
            this.Port = port;

        }

        private void sendobj() //Send Text
        {
            try
            {
                TcpClient client;
                NetworkStream x;
                client = new TcpClient(IP, Port);
                x = client.GetStream();
                StreamWriter writer = new StreamWriter(x);
                writer.Write(Message);
                writer.Flush();
            }
            catch { }
        }

        private void Sentimageobj() //Sent Image
        {
            try
            {
                Message = "c>";
                SendMessage();
                Message = "IM=>";
                SendMessage();
                TcpClient client = new TcpClient();
                NetworkStream mainStream;
                client.Connect(IP, 2015);
                mainStream = client.GetStream();
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                mainStream = client.GetStream();
                binaryFormatter.Serialize(mainStream, Image);
            }
            catch { }
        }
    }
    public class ObjSender
    {
        private string IP;
        private Thread imgsender;
        private TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private int port;
        private object Object;
        public bool SendProcessList { get; set; }

        public ExpandoObject GetProcessExtraInformation(int processId)
        {
            // Query the Win32_Process
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            // Create a dynamic object to store some properties on it
            dynamic response = new ExpandoObject();
            response.Description = "";
            response.Username = "Unknown";

            foreach (ManagementObject obj in processList)
            {
                // Retrieve username 
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    // return Username
                    response.Username = argList[0];

                    // You can return the domain too like (PCDesktop-123123\Username using instead
                    //response.Username = argList[1] + "\\" + argList[0];
                }

                // Retrieve process description if exists
                if (obj["ExecutablePath"] != null)
                {
                    try
                    {
                        FileVersionInfo info = FileVersionInfo.GetVersionInfo(obj["ExecutablePath"].ToString());
                        response.Description = info.FileDescription;
                    }
                    catch { }
                }
            }

            return response;
        }
        protected string GetOpenedProcess()
        {
            string l = "";
            foreach (var y in Process.GetProcesses())
            {
                if (!(y.MainWindowTitle).Equals(""))
                {
                    dynamic extraProcessInfo = GetProcessExtraInformation(y.Id);
                    l += extraProcessInfo.Description + "|" + y.Id + "|" + y.ProcessName + "|" + //ZeyadRemoteControl.Audio.AudioManager.GetApplicationVolume(y.Id) 
                        "Under Construction*"

                        + "|" + y.MainModule.FileName + Environment.NewLine;
                }
            }
            l = l.Remove(l.Length - 1);
            return l;
        }
        public void SendObject()
        {
           
                imgsender = new Thread(SendScreen);
                client.Connect(IP, port);
                imgsender.Start();

        }

        private void StopSharescreen()
        {
            imgsender.Abort();
            client = null;
            mainStream = null;
            SendProcessList = false;

        }

        private void SendScreen()
        {

            try
            {
                if (!SendProcessList)
                {
                    BinaryFormatter Bin = new BinaryFormatter();
                    mainStream = client.GetStream();
                    Bin.Serialize(mainStream, Object);
                    StopSharescreen();
                }

                if (SendProcessList)
                {
                    while (SendProcessList)
                    {

                        BinaryFormatter Bin = new BinaryFormatter();
                        mainStream = client.GetStream();
                        Bin.Serialize(mainStream, GetOpenedProcess());

                    }
                }
            }
            catch { if (SendProcessList) { StopSharescreen(); } }

        }


        public ObjSender(string ip, int port, object obj) // Get IP , Port
        {
            this.IP = ip;
            this.port = port;
            this.Object = obj;

        }

    }
    public class ShareScreen
    {
        private string IP;
        private Thread imgsender;
        private TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private int port;
        public Device Device;

        public void Sharescreen()
        {
            imgsender = new Thread(SendScreen);
            client.Connect(IP, port);
            imgsender.Start();

        }

        public void StopSharescreen()
        {
            imgsender.Abort();
            client = null;
            mainStream = null;

        }
        private void SendScreen()
        {
            while (true)
            {
                try
                {
                    if (Device == Device.Pc)
                    {
                        BinaryFormatter Bin = new BinaryFormatter();
                        mainStream = client.GetStream();
                        Bin.Serialize(mainStream, grabdesktop());
                    }
                    else if (Device == Device.Android)
                    {
                        BinaryFormatter Bin = new BinaryFormatter();
                        mainStream = client.GetStream();
                        Bin.Serialize(mainStream, ImageToByte(grabdesktop()));
                    }
                }
                catch { StopSharescreen(); }
            }
        }

        private Image grabdesktop()
        {
            int screenWidth = Screen.GetBounds(new Point(0, 0)).Width;
            int screenHeight = Screen.GetBounds(new Point(0, 0)).Height;
            Bitmap bmpScreenShot = new Bitmap(screenWidth, screenHeight);
            Graphics gfx = Graphics.FromImage((Image)bmpScreenShot);
            gfx.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));
            return bmpScreenShot;
        }

        private byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public ShareScreen(string ip, int port) // Get IP , Port
        {
            this.IP = ip;
            this.port = port;

        }

    }


 


  


   

}
