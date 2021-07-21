using Android.Content.Res;
using Android.Gms.Ads;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Java.Net;
using Remote_Sender.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using ZeyadRemoteControl.Events.Args;
using ZeyadRemoteControl.NetworkScaners;
using Data = Remote_Sender.Helper.Data;
using FolatingButton = Android.Support.Design.Widget.FloatingActionButton;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Android.Net;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using RemoteSender;

namespace Remote_Sender.Fragments
{

    public class ScanFragment : Android.Support.V4.App.Fragment
    {

        private RecyclerView recycler;
        private RecyclerViewAdapter adapter;
        private RecyclerView.LayoutManager LayoutManger;
        private List<Data> list = new List<Data>();
        private FastPortNetworkScaner Scaner;
        private FolatingButton ScanButton;
        private View CurrentView;
        private ColorStateList defualtColor = null;
        private TextView Iptextview;
        private int ScanPersent;
        private bool Button_Enabled=true;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            MobileAds.Initialize(this.Activity, "ca-app-pub-5898996084033206~3291874723");
            CurrentView =  inflater.Inflate(Resource.Layout.Scan, container, false);
            OnViewCreate();
            return CurrentView;
        }

        private void CheckWifi()
        {
            try
            {
                ConnectivityManager connectivityManager = (ConnectivityManager)Activity.GetSystemService(Android.Content.Context.ConnectivityService);
                NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
                bool isOnline = networkInfo.IsConnected;

                bool isWifi = networkInfo.Type == ConnectivityType.Wifi;
                if (isWifi && networkInfo.IsConnected && GateWayIpAddress()!=null)
                {

                }
                else
                {
                    var builder = new AlertDialog.Builder(this.Activity);

                    builder.SetTitle("Network")
                           .SetMessage("Please Connect To Wifi")
                           .SetPositiveButton("Ok", delegate { System.Environment.Exit(0); }).SetCancelable(false);

                    builder.Create().Show();
                }
            }
            catch
            { }
        }

        public ScanFragment(TextView x)
        {
            Iptextview = x;
            
        }
        
        private void SetupRecyclerView (){
            ClearList();
            recycler = CurrentView.FindViewById<RecyclerView>(Resource.Id.ScaingRecyclerView);
            recycler.HasFixedSize = true;
            LayoutManger = new LinearLayoutManager(Activity);
            recycler.SetLayoutManager(LayoutManger);
            adapter = new RecyclerViewAdapter(list);
            recycler.SetAdapter(adapter);
            adapter.ItemClicked += Adapter_ItemClicked;
         
        }

        private void Adapter_ItemClicked(object sender, RecyclerViewClick Data)
        {
                                                                                  
            try
            {
                if (Data.Data.DeciveName == "Unknow")
                {
                    Toast.MakeText(CurrentView.Context, "Connected To : " + Data.Data.IP, ToastLength.Short).Show();
                }
                else if (Iptextview.Text == Data.Data.IP && Data.Data.DeciveName == "Unknow")
                {
                    Toast.MakeText(CurrentView.Context, "Already Connected To : " + Data.Data.IP, ToastLength.Short).Show();
                }
                else if (Iptextview.Text == Data.Data.IP && Data.Data.DeciveName != "Unknow")
                {
                    Toast.MakeText(CurrentView.Context, "Already Connected To : " + Data.Data.DeciveName, ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(CurrentView.Context, "Connected To : " + Data.Data.DeciveName, ToastLength.Short).Show();
                }
                Iptextview.Text = Data.Data.IP;
            }
            catch { Toast.MakeText(CurrentView.Context, "Error While Connecting", ToastLength.Short).Show(); }
        }

        private void SetUpFloatingButton()
        {
          
            ScanButton = CurrentView.FindViewById<FolatingButton>(Resource.Id.FloatingScanButton);
            ScanButton.Click += ScanButtonClicked;
            ScanButton.LongClick += ScanButton_LongClick;
        }

        private void ScanButton_LongClick(object sender, View.LongClickEventArgs e)
        {
            SetIP();
        }

        private void SetScaner()
        {
            if (GateWayIpAddress() != null)
            {
                Scaner = new FastPortNetworkScaner(16, 7575, GateWayIpAddress());
                Scaner.NewIpFound += FoundIp;
                Scaner.Finshed += ScanFinshed;
                Scaner.Update += Scaner_Update;
            }
        }

        private void Scaner_Update(object sender, FastScanUpdateEvent IP)
        {
        }

        private string GateWayIpAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        var myip = ip.ToString();
                        string Ipaddress = myip.Split(char.Parse("."))[0] + "." + myip.Split(char.Parse("."))[1] + "." + myip.Split(char.Parse("."))[2] + "." + "1";
                        return Ipaddress;
                    }
                }
            }
            catch
            {
                Toast.MakeText(CurrentView.Context, "Can't Get Router IP Address", ToastLength.Short).Show();
                return null;
            }
            return null;
        }

        private void ScanButtonClicked(object sender, EventArgs e)
        {
            if (Button_Enabled)
            {
                CheckWifi();
                if (GateWayIpAddress() != null)
                {
                    ClearList();
                    Toast.MakeText(CurrentView.Context, "Scan Started", ToastLength.Short).Show();
                    SetScaner();
                    defualtColor = ScanButton.BackgroundTintList;
                    Scaner.StartScan();
                    Button_Enabled = false;
                    ColorStateList csl = new ColorStateList(new int[][] { new int[0] }, new int[] { Android.Graphics.Color.ParseColor("#808281") }); ScanButton.BackgroundTintList = csl;
                }
                else
                {
                    Toast.MakeText(CurrentView.Context, "Error", ToastLength.Short).Show();
                }
            }
            else
            {
                Scaner.StopScan();
                Button_Enabled = true;
                ScanButton.BackgroundTintList = defualtColor;
                Scaner = null;
                ScanPersent = 0;
                Toast.MakeText(CurrentView.Context, "Scan Aborted", ToastLength.Long).Show();
            }
        }
        private void ScanFinshed(object sender, FinshedScaning e)
        {
            Activity.RunOnUiThread(() =>
            {
                Button_Enabled = true;
                ScanButton.BackgroundTintList = defualtColor;
                Scaner.StopScan();
                Scaner = null;
                ScanPersent = 0;
                Toast.MakeText(CurrentView.Context, "Scan Finshed", ToastLength.Long).Show();
            });
        }
        private void FoundIp(object sender, FastScanNewIpFoundEvent IP)
        {
            Activity.RunOnUiThread(() =>
                {
                    AddItem(new Data() { DeciveName = GetmMachineName(IP.IP), IP = IP.IP, ImageId = Resource.Mipmap.Desktop, ShowInfo = ViewStates.Invisible });

                });
        }

        private string GetRequest(System.Uri uri, int timeoutMilliseconds)
        {
            try
            {
                var request = System.Net.WebRequest.Create(uri);
                request.Timeout = timeoutMilliseconds;
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new System.IO.StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch
            {

                return "Unkown";
            }
        }
        private string GetmMachineName(string iP)
        {
            string machineName="Unknow";
            var url = new System.Uri("http://" + iP + ":415/");
            try
            {
                System.String htmlCode = GetRequest(url, 1000);
                htmlCode = htmlCode.Remove(0, 16);
                htmlCode = htmlCode.Remove(htmlCode.Length - 7);
                machineName = htmlCode;
            }
            catch
            {
                machineName = "Unknown";
            }

            return machineName;
        }
        private void AddItem(Data data)
        {
            if (data != null)
            {
                try { 
                    list.Add(data);
                    adapter.NotifyItemInserted(list.IndexOf(data));
                }
                catch
                { }
            }
        }

        private void ClearList()
        {
            Remove:
            if (list.Count > 0)
            {
                
                for (int x = 0; x < list.Count; x++)
                {
                    list.Remove(list[x]);
                    adapter.NotifyItemRemoved(x);
                }
            }

            if (list.Count > 0)
            {
                goto Remove;
            }
            else
            {
                AddItem(new Data());
            }
           
        }

        private void OnViewCreate()
        {
            SetupRecyclerView();
            SetUpFloatingButton();
            SetAdView();    
        }

        private void SetAdView()
        {
            //load Ad First Time
            AdView mAdView;
            mAdView = (AdView)CurrentView.FindViewById(Resource.Id.ScanAdView);
            AdRequest adRequest = new AdRequest.Builder().Build();
            mAdView.LoadAd(adRequest);

            //Change Ad Every 5 Seconds
            Task.Run(async () =>
            {
                while (true)
                {
                    Activity.RunOnUiThread(() =>
                    {
                        mAdView = (AdView)CurrentView.FindViewById(Resource.Id.ScanAdView);
                        adRequest = new AdRequest.Builder().Build();
                        mAdView.LoadAd(adRequest);
                    });
                    await Task.Delay(5000);
                }
            });

        }

        private bool IsPortOpened(string IP, int port)
        {
            var hostname = IPAddress.Parse(IP);
            var Port = port;
            var timeout = TimeSpan.FromSeconds(1);
            var client = new TcpClient();
            try
            {
                if (client.ConnectAsync(hostname, port).Wait(timeout))
                {
                    client.Dispose();
                    return true;
                }
                else { client.Dispose(); return false; }
            }
            catch
            {
                client.Dispose();
                return false;
            }

        }
        private void SetIP()
        {
            LayoutInflater layoutInflater = LayoutInflater.From(Activity);
            View view = layoutInflater.Inflate(Resource.Layout.GetIp, null);
            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(Activity);
            alertbuilder.SetView(view);
            var userdata = view.FindViewById<EditText>(Resource.Id.editText);
            alertbuilder.SetCancelable(false)
            .SetPositiveButton("Submit", delegate
            {
                if (IsPortOpened(userdata.Text, 7575))
                {
                    Iptextview.Text = userdata.Text;
                    Toast.MakeText(CurrentView.Context, "Connected To : " + userdata.Text, ToastLength.Short).Show();
                }
                else {
                    Toast.MakeText(CurrentView.Context, "Can't Connect", ToastLength.Short).Show();

                }
            })
            .SetNegativeButton("Cancel", delegate
            {

            });
            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
            dialog.Show();
        }
    }
}