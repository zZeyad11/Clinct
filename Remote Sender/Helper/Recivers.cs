using Android.App;
using Android.Graphics;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using ZeyadRemoteControl.Events;
using ZeyadRemoteControl.Events.Args;

namespace Remote_Sender.Recivers
{

    public class ObjReciver
    {
        private TcpClient client;
        private TcpListener server;
        private NetworkStream mainStream;
        private readonly Thread listening;
        private readonly Thread GetImage;
        public object Object;
        public event RecivedObject Update;
        public event Failure Failure;
        RecivedObjectEvent imagetoshow = new RecivedObjectEvent();
        private int port;
        public ObjReciver(int port)
        {
            client = new TcpClient();
            listening = new Thread(startlistening);
            GetImage = new Thread(reciveImage);
            this.port = port;
        }


        private void startlistening()
        {

            while (!client.Connected)
            {
                try
                {

                    server.Start();
                    client = server.AcceptTcpClient();

                }
                catch
                {

                }
            }
            GetImage.Start();
        }
        public void Stop()
        {
            server.Stop();
            client = null;
            try { listening.Abort(); GetImage.Abort(); } catch { Failure(this); }
        }

        string GetMyIp()
        {
            string IP="127.0.0.1";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    var myip = ip.ToString();
                    IP = myip;
                    
                }
            }
            return IP;
        }
        public void Start()
        {
            try
            {
                server = new TcpListener(IPAddress.Parse(GetMyIp()),port);
                server.Start();
                listening.Start();
            }
            catch
            {
                try
                {
                    Failure(this);
                }
                catch 
                {

                   
                } }
        }
        private void reciveImage()
        {

            BinaryFormatter bin = new BinaryFormatter();
            while (client.Connected)

            {
                try
                {
                    mainStream = client.GetStream();
                    Object = bin.Deserialize(mainStream);
                    imagetoshow.Obj = Object;
                    Update(this, imagetoshow);
                }
                catch
                {
                    this.Failure(this);
                    Stop();
                }

            }


        }


    }

    public class ImageReciver
    {



        private TcpClient client;
        private TcpListener server;
        private NetworkStream mainStream;
        private readonly Thread listening;
        private readonly Thread GetImage;
        private Bitmap Image;
        public event Recived Update;
        RecivedFinshed imagetoshow = new RecivedFinshed();
        private int port;
        public bool Connected { get; set; }
        public bool Once { get; set; }
        public ImageReciver(int port)
        {
            client = new TcpClient();
            listening = new Thread(startlistening);
            GetImage = new Thread(reciveImage);
            Connected = false;
            this.port = port;
        }


        private void startlistening()
        {

            while (!client.Connected)
            {

                imagetoshow.Image = Image;
                Update(this, imagetoshow);
                try
                {

                    server.Start();
                    client = server.AcceptTcpClient();

                }
                catch
                {

                }
            }
            GetImage.Start();
        }
        public void Stop()
        {
            try
            {
                server.Stop();
                client = null;
                try { listening.Abort(); GetImage.Abort(); } catch { }
            }
            catch { }
        }

        public void Start()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                listening.Start();
            }
            catch { }
        }
        private void reciveImage()
        {
            try
            {
                BinaryFormatter bin = new BinaryFormatter();
                while (client.Connected && client != null)

                {
                    try
                    {
                        mainStream = client.GetStream();
                        var image = bin.Deserialize(mainStream);
                        Image = byteArrayToImage(((byte[])image));
                        Connected = true;
                        imagetoshow.Image = Image;
                        Update(this, imagetoshow);
                    }
                    catch (Exception)
                    {
                        if (!Once)
                        {
                            
                            imagetoshow.Image = BitmapFactory.DecodeResource(Application.Context.Resources,RemoteSender.Resource.Drawable.noFeed);
                            Update(this, imagetoshow);
                            Connected = false;
                        }

                    }

                }
            }
            catch
            {


            }


        }

        private static bool IsPortOpen(string host, int port)
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(host, port);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }

        Bitmap byteArrayToImage(byte[] v)
        {
            Bitmap bmp = BitmapFactory.DecodeByteArray(v, 0, v.Length);
            return bmp;
        }

    }

}
