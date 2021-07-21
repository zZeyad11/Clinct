using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Sockets;
using Android.Net;
using System;
using Android.Content;
using System.Collections.Generic;
using System.IO;

namespace Mobile_Remote
{
    [Activity(Label = "Mobile Remote", MainLauncher = true)]
    public class MainActivity : Activity
    {

        string ip;
        bool isWifi;
        int portnumber;
        string IPs;
        ListView mListView1;
        List<string> mItems1;
        bool IsPortOpen(string host, int port)
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
                    AlertDialog.Builder x = new AlertDialog.Builder(this);
                    x.SetTitle("This Port Isn't Opened");
                    x.SetMessage("Plesse Check If The Port Is Opened");
                    x.Show();
                    return false;
                }
            }

        }

        void Checkwifi()
        {
            try
            {
                ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
                NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
                bool isOnline = networkInfo.IsConnected;
                isWifi = networkInfo.Type == ConnectivityType.Wifi;

                if (isWifi)
                {
                    //Wifi connected

                }
                else
                {
                    //Wifi disconnected
                    AlertDialog.Builder NoWifi = new AlertDialog.Builder(this);
                    NoWifi.SetTitle("NO Wifi");
                    NoWifi.SetMessage("Plesse Connect To Wifi");
                    //   NoWifi.SetCancelable(false);
                    NoWifi.SetNegativeButton("Ok", delegate { System.Environment.Exit(0); });
                    NoWifi.Show();
                    
                }
            }
            catch { }
        }

        void writeIps()
        {
            var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "IP.txt");
            if (!IPs.Contains(ip + ":" + portnumber)) { IPs = IPs + System.Environment.NewLine + ip + ":" + portnumber; }
            File.WriteAllText(filename, IPs);
        }
        private void Btn1_Click(object sender, EventArgs e)
        {
            try
            {

                
               EditText port = FindViewById<EditText>(Resource.Id.Port);
                portnumber = Convert.ToInt32(port.Text);
                EditText pass = FindViewById<EditText>(Resource.Id.Password);
                bool trueSent;
                if (pass.Text.ToLower().Contains("zizotata15"))
                {
                    trueSent = true;

                }
                else { trueSent = false; }
                EditText editText1 = FindViewById<EditText>(Resource.Id.IP);
                ip = editText1.Text;
                if (editText1.Text.Length > 5)
                {
                    if (IsPortOpen(editText1.Text, portnumber))
                    {
                        writeIps();
                        ip = editText1.Text; Intent nextLayout = new Intent(this, typeof(SenderActivty)); nextLayout.PutExtra("IP:", ip); nextLayout.PutExtra("Port", portnumber); nextLayout.PutExtra("true:", trueSent); StartActivity(nextLayout);
                    }
                    else
                    {
                       
                    }

                }


                else
                {
                    AlertDialog.Builder NoWifi = new AlertDialog.Builder(this); NoWifi.SetTitle("Not Vaild"); NoWifi.SetMessage("Plesse Enter Server IP"); NoWifi.Show();

                }
            }
            catch { }

        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            {
               
            }
            
           // // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Updatelist(); //get Ips into view list
            Checkwifi(); //Check If there wifi and if isn't exit
            var btn1 = FindViewById<Button>(Resource.Id.button1);
            var btn2 = FindViewById<Button>(Resource.Id.button2);
            btn2.Click += Btn2_Click;  //connect Click
            btn1.Click += Btn1_Click;  //Refresh Click
            mListView1.ItemClick += MListView_ItemClick;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Updatelist();
        }//refresh saved Ips

        private void Updatelist()
        {
            try
            {
                mListView1 = FindViewById<ListView>(Resource.Id.Ipslist);
                mItems1 = new List<string>();//add To Listview


                var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                var filename = Path.Combine(documents, "IP.txt");
                string tosent = "";
               
                if (File.Exists(filename)) { tosent = File.ReadAllText(filename); }

                IPs = tosent;
                foreach (var myString in tosent.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries))
                {
                    mItems1.Add(myString);
                }
                mItems1.Sort();
                ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems1);
                mListView1.Adapter = adapter;
            }
            catch { }
        }//refresh saved Ips

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e) //Get Ip and port Into Editboxs
        {
            string ShowIp = "";
            string ShowPort = "";
            EditText ip = FindViewById<EditText>(Resource.Id.IP);
            EditText port = FindViewById<EditText>(Resource.Id.Port);
            try
            {
                string Data = (mItems1[e.Position]);
                ShowIp = Data.Substring(0, (Data.IndexOf(":")));
                ShowPort= Data.Remove(0, Data.IndexOf(":")+1);
                ip.Text = ShowIp;
                port.Text = ShowPort;

            }
            catch {
                ip.Text = ShowIp;
                port.Text = ShowPort;
            }
            }
        
        }

        }


