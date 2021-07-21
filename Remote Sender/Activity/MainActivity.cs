using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Scan = Remote_Sender.Fragments.ScanFragment;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Tools = Remote_Sender.Fragments.ToolsFragment;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using System;
using Android.Gms.Ads;
using Remote_Sender.Helper;
using Remote_Sender.Fragments;
using Remote_Sender.Senders;
using System.Net.Sockets;
using System.Threading.Tasks;
using RemoteSender;

namespace Remote_Sender
{
    [Activity(Label = "Remote", Theme = "@style/Theme.DesignDemo",ScreenOrientation =Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout drawerLayout;
        private Scan ScanFragment;
        protected InterstitialAd mInterstitialAd;
        public bool IsPortOpen(string host, int port)
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

        private void ShowNotConnected()
        {
            try
            {
                    var builder = new AlertDialog.Builder(this);
                    builder.SetTitle("Not Connected")
                           .SetMessage("Please Connect To Device First")
                           .SetPositiveButton("Ok", delegate {}).SetCancelable(false);

                    builder.Create().Show();
                
            }
            catch
            { }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {

           
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource 
            MobileAds.Initialize(this, "ca-app-pub-5898996084033206~3291874723");
            SetContentView(Resource.Layout.main);
            SetNavgationView();
            CheckWifi();

        }

        
        private void CheckWifi()
        {
            try
            {
                ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
                NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
                bool isOnline = networkInfo.IsConnected;

                bool isWifi = networkInfo.Type == ConnectivityType.Wifi;
                if (isWifi && networkInfo.IsConnected)
                {

                }
                else
                {
                    var builder = new AlertDialog.Builder(this);

                    builder.SetTitle("Network")
                           .SetMessage("Please Connect To Wifi")
                           .SetPositiveButton("Ok", delegate { System.Environment.Exit(0); }).SetCancelable(false);

                    builder.Create().Show();
                }
            }
            catch { }
        }

        private void ShowScanFragment(TextView x)
        {
            if (ScanFragment == null)
            {
                ScanFragment = new Scan(x);
            }
            Android.Support.V4.App.FragmentTransaction transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.framelayout, ScanFragment).Commit();
        }

        private void SetNavgationView()
        {
            SupportToolbar toolbar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolbar);
            SupportActionBar ab = SupportActionBar;
            SupportActionBar.Title = "Scan";
            ab.SetHomeAsUpIndicator(Resource.Drawable.Menu);
            ab.SetDisplayHomeAsUpEnabled(true);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            }
        }

        private void ShowInterstitialAd()
        {
            var adRequest = new AdRequest.Builder().Build();
            mInterstitialAd = new InterstitialAd(Application.Context);
            mInterstitialAd.AdUnitId = "ca-app-pub-5898996084033206/8764102371";
            mInterstitialAd.LoadAd(adRequest);
            mInterstitialAd.Show();
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }


        private void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.SetCheckedItem(Resource.Id.Scan);
            View nav_header = LayoutInflater.From(this).Inflate(Resource.Layout.Header, null);
            navigationView.AddHeaderView(nav_header);
            TextView IPText = nav_header.FindViewById<TextView>(Resource.Id.IPTextView);
            ShowScanFragment(IPText);
            navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                drawerLayout.CloseDrawers();

                Android.Support.V4.App.FragmentTransaction transaction1 = SupportFragmentManager.BeginTransaction();
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.Scan:
                        {
                            if (IPText != null && IPText.Text != "IP")
                            {
                                    //Scaning
                                    SupportActionBar.Title = "Scan";
                                    Scan home = ScanFragment;
                                    transaction1.Replace(Resource.Id.framelayout, home).Commit();
                                e.MenuItem.SetChecked(true);
                            }
                            break;
                        }
                    //case Resource.Id.Live:
                    //    {
                    //        if (IPText != null && IPText.Text != "IP")
                    //        {
                    //            if (IsPortOpen(IPText.Text, 7575))
                    //            {
                    //                MessageSender Sender = new MessageSender(IPText.Text, 7575);
                    //                Sender.Message = "androidshare";
                    //                Sender.SendMessage();
                    //                //Live View
                    //                Intent intent = new Intent(this, typeof(Live));
                    //                StartActivity(intent);
                    //            }
                    //            else
                    //            {
                    //                ShowNotConnected();
                                    

                    //            }
                    //        }
                    //        else
                    //        {
                    //            ShowNotConnected();
                    //        }
                    //        break;


                    //    }
                    case Resource.Id.Tools:
                        {
                            if (IPText != null && IPText.Text != "IP")
                            {
                                if (IsPortOpen(IPText.Text, 7575))
                                {
                                    //Tools
                                    SupportActionBar.Title = "Tools";
                                    Tools tools = new Tools(IPText);
                                    transaction1.Replace(Resource.Id.framelayout, tools).Commit();
                                    e.MenuItem.SetChecked(true);
                                }
                                else
                                {
                                    ShowNotConnected();
                                }
                            }
                            else
                            {
                                ShowNotConnected();
                            }
                            break;
                        }
                    case Resource.Id.Processes:
                        {
                            //Processes
                            if (IPText != null && IPText.Text != "IP")
                            {
                                if (IsPortOpen(IPText.Text, 7575))
                                {
                                    MessageSender ZSend;
                                    ZSend = new MessageSender(IPText.Text, 7575);
                                    ZSend.Message = "GetProcessesList";
                                    ZSend.SendMessage();
                                    SupportActionBar.Title = "Processes";
                                    ProcessesFragment Processes = new ProcessesFragment(IPText);
                                    transaction1.Replace(Resource.Id.framelayout, Processes).Commit();
                                    e.MenuItem.SetChecked(true);
                                }
                                else
                                {
                                    ShowNotConnected();
                                }
                            }
                            else
                            {
                                ShowNotConnected();
                            }
                            break;
                        }
                    //case Resource.Id.Settings:
                    //    {
                    //        ShowInterstitialAd();
                    //        Intent intent = new Intent(this, typeof(Settings));
                    //        StartActivity(intent);
                    //        break;
                    //    }
                }
                };
        }
    }
}

