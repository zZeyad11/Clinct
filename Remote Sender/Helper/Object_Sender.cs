using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Sockets;
using System.IO;
using Java.Lang;
using System.Runtime.Serialization.Formatters.Binary;
using Android.Media;

namespace Remote_Sender
{
    class ObjSender
    {
        string IP;
        int Port;
        Thread msgsender = new Thread();
        Thread imgsender = new Thread();
        public string Message {get;set;}
        public byte[] Image { get; set; }
        public void SendMessage()
        {
            
            if(Message != "")
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
        public ObjSender(string ip,int port) // Get IP , Port
        {
            this.IP = ip;
            this.Port = port;

        }
      
        private void sendobj() //Send Text
        {
            TcpClient client;
            NetworkStream x;
            client = new TcpClient(IP, Port);
            x = client.GetStream();
            StreamWriter writer = new StreamWriter(x);
            writer.Write(Message);
            writer.Flush();
        }

        private void Sentimageobj() //Sent Image
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
    }
}