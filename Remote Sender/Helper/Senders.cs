using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Remote_Sender.Senders
{
    public class ObjSender
    {
        private string IP;
        private Thread imgsender;
        private TcpClient client = new TcpClient();
        private NetworkStream mainStream;
        private int port;
        private object Object;
        public bool SendForever { get; set; }


        static string GetOpenedProcess()
        {
            string l = "";
            foreach (var y in Process.GetProcesses())
            {
                if (!(y.MainWindowTitle).Equals(""))
                {
                    l += y.MainWindowTitle + "|";
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
            SendForever = false;

        }

        private void SendScreen()
        {

            try
            {
                if (!SendForever)
                {
                    BinaryFormatter Bin = new BinaryFormatter();
                    mainStream = client.GetStream();
                    Bin.Serialize(mainStream, Object);
                    StopSharescreen();
                }

                if (SendForever)
                {
                    while (SendForever)
                    {

                        BinaryFormatter Bin = new BinaryFormatter();
                        mainStream = client.GetStream();
                        Bin.Serialize(mainStream, ObjSender.GetOpenedProcess());

                    }
                }
            }
            catch { if (SendForever) { StopSharescreen(); } }

        }


        public ObjSender(string ip, int port, object obj) // Get IP , Port
        {
            this.IP = ip;
            this.port = port;
            this.Object = obj;

        }

    }

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

}
