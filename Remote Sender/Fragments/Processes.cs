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
using Remote_Sender.Recivers;
using System.Linq;
using RemoteSender;
using Remote_Sender.Senders;
using Android.App;

namespace Remote_Sender.Fragments
{

    public class ProcessesFragment : Android.Support.V4.App.Fragment
    {

        private RecyclerView recycler;
        private RecyclerViewAdapter adapter;
        private RecyclerView.LayoutManager LayoutManger;
        private List<Data> list = new List<Data>();
        private View CurrentView;
        private TextView Iptextview;
        private ObjReciver reciver;
        private List<Processes> ProcessList = new List<Processes>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            MobileAds.Initialize(this.Activity, "ca-app-pub-5898996084033206~3291874723");
            var view = inflater.Inflate(Resource.Layout.Process, container, false);
            CurrentView = view;
            OnViewCreate();
            return view;
        }

        private void CheckWifi()
        {
            try
            {
                ConnectivityManager connectivityManager = (ConnectivityManager)Activity.GetSystemService(Android.Content.Context.ConnectivityService);
                NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
                bool isOnline = networkInfo.IsConnected;

                bool isWifi = networkInfo.Type == ConnectivityType.Wifi;
                if (isWifi && networkInfo.IsConnected)
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
        public System.String GetCurrentIP()
        {

            return Iptextview.Text;
        }

        public ProcessesFragment(TextView x)
        {
            Iptextview = x;
            
        }
        
        private void SetupRecyclerView (){

            list.Add(new Data());
            recycler = CurrentView.FindViewById<RecyclerView>(Resource.Id.ProcessesRecyclerView);
            recycler.HasFixedSize = true;
            LayoutManger = new LinearLayoutManager(Activity);
            recycler.SetLayoutManager(LayoutManger);
            adapter = new RecyclerViewAdapter(list);
            recycler.SetAdapter(adapter);
            adapter.ItemClicked += Adapter_ItemClicked;
            adapter.InfoClicked += Adapter_InfoClicked;

        }

        private void Adapter_InfoClicked(object sender, RecyclerViewClick Data)
        {
            var ip = Iptextview.Text;
            Processes t=null;
            MessageSender Sender = new MessageSender(ip, 7575);
            foreach(var a in ProcessList)
            {
                if(a.Description == Data.Data.DeciveName)
                {
                    t = a;
                }
            }
            var position = list.IndexOf(Data.Data);
            list.Remove(Data.Data);
            adapter.NotifyItemRemoved(position);
            Sender.Message = "W_Kill " + ProcessList[ProcessList.IndexOf(t)].Description;
            Sender.SendMessage();
        }

        private void Adapter_ItemClicked(object sender, RecyclerViewClick Data)
        {
            LayoutInflater layoutInflater = LayoutInflater.From(Activity);
            View view = layoutInflater.Inflate(Resource.Layout.GetMessage, null);
            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(Activity);
            alertbuilder.SetView(view);
            var userdata = view.FindViewById<EditText>(Resource.Id.editText);
            userdata.Visibility = ViewStates.Gone;
            ((TextView)(view.FindViewById(Resource.Id.dialogTitle))).Text = "Kill Process";
            alertbuilder.SetCancelable(false)
            .SetPositiveButton("Confirm", delegate
            {

                var x = ProcessList.Find(a => a.Description == Data.Data.DeciveName);
                var Id = x.ProcessID;

                //Send Kill Message
                var Sender = new ObjSender(GetCurrentIP(), 7575);
                Sender.Message = "W_Kill " + Id;
                Sender.SendMessage();
            })
            .SetNegativeButton("Cancel", delegate
            {

            }
            );
            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
            dialog.Show();


        }
        private void AddItem(Data data)
        {
                    list.Add(data);
                    adapter.NotifyItemInserted(list.IndexOf(data));
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
            SetUpReciver();
            SetAdView();
        }

        private void SetUpReciver()
        {
            reciver = new ObjReciver(7645);
            reciver.Start();
            reciver.Update += (s,e) => {
                Activity.RunOnUiThread(() =>
                {
                    //Recived Process List
                    List<Processes> Processes = new List<Processes>();
                    foreach (string x in ((string)e.Obj).Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        var Process = new Processes(x);
                        Processes.Add(Process);
                    }


                    //Add New Process To View
                    var NewProcesses = Processes.Except(Processes.Where(o => ProcessList.Select(y => y.ProcessName).ToList().Contains(o.ProcessName))).ToList(); //New Processes
                    foreach(var Process in NewProcesses)
                    {
                        try
                        {
                            var New_Data = new Data() { DeciveName = Process.Description, ImageId = Resource.Mipmap.ic_process, ShowInfo = ViewStates.Visible, InfoImageId = Resource.Mipmap.ic_close };
                            AddItem(New_Data);
                            ProcessList.Add(Process);
                        }
                        catch
                        {

                           
                        }
                    }

                    //Get Rid Of Old Process
                    var OldProcesses = ProcessList.Except(ProcessList.Where(o => Processes.Select(y => y.ProcessName).ToList().Contains(o.ProcessName))).ToList(); //Old Processes
                    foreach (var process in OldProcesses)
                    {
                        try
                        {
                            Data x = list.Find(i => i.DeciveName == process.Description);
                            var Index = list.IndexOf(x);
                            list.Remove(x);
                            adapter.NotifyItemRemoved(Index);
                            ProcessList.Remove(process);
                        }
                        catch
                        {

                         
                        }
                    }
                });

            };
            reciver.Failure += (s) =>
            {
                Toast.MakeText(Application.Context, "Unknown Failure",ToastLength.Short).Show();
            };
        }

    

        private void SetAdView()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    Activity.RunOnUiThread(() =>
                    {
                        AdView mAdView;
                        mAdView = (AdView)CurrentView.FindViewById(Resource.Id.ProAdView);
                        AdRequest adRequest = new AdRequest.Builder().Build();
                        mAdView.LoadAd(adRequest);
                    });
                    await Task.Delay(3000);
                }
            });

        }
    }
}