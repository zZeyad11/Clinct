using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Gms.Ads;
using Android.OS;
using Android.Provider;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Remote_Sender.Helper;
using RemoteSender;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Remote_Sender.Fragments
{
    public class ToolsFragment : Android.Support.V4.App.Fragment
    {

        private RecyclerView recycler;
        private RecyclerViewAdapter adapter;
        private RecyclerView.LayoutManager LayoutManger;
        private List<Data> list = new List<Data>();
        private View CurrentView;
        private TextView Iptextview;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }


        public ToolsFragment(TextView x)
        {
            this.Iptextview = x;
        }

        public String GetCurrentIP()
        {

            return Iptextview.Text;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Tools, container, false);
            CurrentView = view;
            OnViewCreate();
            return view;
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
                        mAdView = (AdView)CurrentView.FindViewById(Resource.Id.ToolsAdView);
                        AdRequest adRequest = new AdRequest.Builder().Build();
                        mAdView.LoadAd(adRequest);
                    });
                    await Task.Delay(5000);
                }
            });

        }

        private void SendMessage()
        {
            LayoutInflater layoutInflater = LayoutInflater.From(Activity);
            View view = layoutInflater.Inflate(Resource.Layout.GetMessage, null);
            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(Activity);
            alertbuilder.SetView(view);
            var userdata = view.FindViewById<EditText>(Resource.Id.editText);
            alertbuilder.SetCancelable(false)
            .SetPositiveButton("Submit", delegate
            {                 
                    var Sender = new ObjSender(GetCurrentIP(), 7575);
                    Sender.Message = ">" + userdata.Text;
                    Sender.SendMessage();
            })
            .SetNegativeButton("Cancel", delegate
            {
               
            }
            ).SetNeutralButton("Show every word separated", delegate {
                var Sender = new ObjSender(GetCurrentIP(), 7575);
                Sender.Message = "l>" + userdata.Text;
                Sender.SendMessage();

            });
            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
            dialog.Show();
        }
        private void SetupRecyclerView()
        {
            list.Add(new Data());
            recycler = CurrentView.FindViewById<RecyclerView>(Resource.Id.ToolsRecyclerView);
            recycler.HasFixedSize = true;
            LayoutManger = new LinearLayoutManager(Activity);
            recycler.SetLayoutManager(LayoutManger);
            adapter = new RecyclerViewAdapter(list);
            recycler.SetAdapter(adapter);
            adapter.ItemClicked += Adapter_ItemClicked;


        }

        private void Adapter_ItemClicked(object sender, RecyclerViewClick Data)
        {
            ObjSender Sender;
            switch (Data.Data.DeciveName)
            {
                case "Lock Windows":
                    try
                    {
                        {
                            LayoutInflater layoutInflater = LayoutInflater.From(Activity);
                            View view = layoutInflater.Inflate(Resource.Layout.GetMessage, null);
                            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                            alertbuilder.SetView(view);
                            var userdata = view.FindViewById<EditText>(Resource.Id.editText);
                            userdata.Visibility = ViewStates.Gone;
                            ((TextView)(view.FindViewById(Resource.Id.dialogTitle))).Text="Lock Windows";
                            alertbuilder.SetCancelable(false)
                            .SetPositiveButton("Confirm", delegate
                            {
                                Sender = new ObjSender(GetCurrentIP(), 7575);
                                Sender.Message = "wlock";
                                Sender.SendMessage();
                            })
                            .SetNegativeButton("Cancel", delegate
                            {

                            }
                            );
                            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
                            dialog.Show();
                        }
                    }
                    catch {Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show();}
                    break;
                case "Sign Out":
                    try
                    {
                        {
                            LayoutInflater layoutInflater = LayoutInflater.From(Activity);
                            View view = layoutInflater.Inflate(Resource.Layout.GetMessage, null);
                            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                            alertbuilder.SetView(view);
                            var userdata = view.FindViewById<EditText>(Resource.Id.editText);
                            userdata.Visibility = ViewStates.Gone;
                            ((TextView)(view.FindViewById(Resource.Id.dialogTitle))).Text = "Sign Out";
                            alertbuilder.SetCancelable(false)
                            .SetPositiveButton("Confirm", delegate
                            {
                                Sender = new ObjSender(GetCurrentIP(), 7575);
                                Sender.Message = "/shutdown -l -f";
                                Sender.SendMessage();
                            })
                            .SetNegativeButton("Cancel", delegate
                            {

                            }
                            );
                            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
                            dialog.Show();
                        }
                        

                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
                case "Shutdown":
                    try
                    {
                        {
                            LayoutInflater layoutInflater = LayoutInflater.From(Activity);
                            View view = layoutInflater.Inflate(Resource.Layout.GetMessage, null);
                            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                            alertbuilder.SetView(view);
                            var userdata = view.FindViewById<EditText>(Resource.Id.editText);
                            userdata.Visibility = ViewStates.Gone;
                            ((TextView)(view.FindViewById(Resource.Id.dialogTitle))).Text = "Shutdown";
                            alertbuilder.SetCancelable(false)
                            .SetPositiveButton("Confirm", delegate
                            {
                                Sender = new ObjSender(GetCurrentIP(), 7575);
                                Sender.Message = "/shutdown -s -t 1";
                                Sender.SendMessage();
                            })
                            .SetNegativeButton("Cancel", delegate
                            {

                            }
                            );
                            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
                            dialog.Show();
                        }
                      
                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
                case "Sleep":
                    try
                    {
                        {
                            LayoutInflater layoutInflater = LayoutInflater.From(Activity);
                            View view = layoutInflater.Inflate(Resource.Layout.GetMessage, null);
                            Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                            alertbuilder.SetView(view);
                            var userdata = view.FindViewById<EditText>(Resource.Id.editText);
                            ((TextView)(view.FindViewById(Resource.Id.dialogTitle))).Text = "Sleep";
                            userdata.Visibility = ViewStates.Gone;
                            alertbuilder.SetCancelable(false)
                            .SetPositiveButton("Confirm", delegate
                            {
                                Sender = new ObjSender(GetCurrentIP(), 7575);
                                Sender.Message = "wsleep";
                                Sender.SendMessage();
                            })
                            .SetNegativeButton("Cancel", delegate
                            {

                            }
                            );
                            Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
                            dialog.Show();
                        }
                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
                case "Volume Up":
                    try
                    {
                        Sender = new ObjSender(GetCurrentIP(), 7575);
                        Sender.Message = "wvu";
                        Sender.SendMessage();
                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
                case "Volume Down":
                    try
                    {
                        Sender = new ObjSender(GetCurrentIP(), 7575);
                        Sender.Message = "wvd";
                        Sender.SendMessage();
                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
                case "Mute":
                    try
                    {
                        Sender = new ObjSender(GetCurrentIP(), 7575);
                        Sender.Message = "wmute";
                        Sender.SendMessage();
                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
                case "Show Full Screen Text":
                    SendMessage();
                    break;
                case "Show Full Screen Image":
                    try
                    {
                        var Intent = new Intent();
                        Intent.SetType("image/*");
                        Intent.SetAction(Intent.ActionGetContent);
                        StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), 520);
                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
                case "Close Shown":
                    try
                    {
                        Sender = new ObjSender(GetCurrentIP(), 7575);
                        Sender.Message = "c>";
                        Sender.SendMessage();

                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
                case "Play Previous":
                    try
                    {
                        Sender = new ObjSender(GetCurrentIP(), 7575);
                        Sender.Message = "PlayPREV";
                        Sender.SendMessage();
                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
                case "Toggle Play":
                    try
                    {
                        Sender = new ObjSender(GetCurrentIP(), 7575);
                        Sender.Message = "TogglePlay";
                        Sender.SendMessage();
                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
                case "Play Next":
                    try
                    {
                        Sender = new ObjSender(GetCurrentIP(), 7575);
                        Sender.Message = "PlayNext";
                        Sender.SendMessage();
                    }
                    catch { Snackbar.Make(CurrentView, "Error While Sending", Snackbar.LengthShort).Show(); }
                    break;
            }
        }

        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if ((requestCode == 520) && (resultCode == -1) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                try
                {
                    Android.Graphics.Bitmap bitmap = MediaStore.Images.Media.GetBitmap(Activity.ContentResolver, data.Data);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, stream);
                        var imageinbyte = stream.ToArray();
                        try
                        {
                            if (imageinbyte != null)
                            {
                                var Sender = new ObjSender(GetCurrentIP(), 7575);
                                Sender.Image = imageinbyte;
                                Sender.SendImage();
                            }
                        }
                        catch { }

                    }

                }

                catch { }


            }
        }

        private void AddItem(Data data)
        {
            list.Add(data);
            adapter.NotifyItemInserted(list.IndexOf(data));
        }

        private void ClearList()
        {
            if (list.Count > 0)
            {
                for (int x = 0; x < list.Count; x++)
                {
                    list.Remove(list[x]);
                    adapter.NotifyItemRemoved(x);
                }
            }
            AddItem(new Data());
        }

        private void OnViewCreate()
        {
            SetupRecyclerView();
            SetCommands();
            SetAdView();
        }

        private void SetCommands()
        {
            //Control
            AddItem(new Data() {DeciveName = "Lock Windows" , ImageId=Resource.Mipmap.@lock, ShowInfo = Android.Views.ViewStates.Invisible });
            AddItem(new Data() { DeciveName = "Sign Out", ImageId = Resource.Mipmap.SignOut, ShowInfo = Android.Views.ViewStates.Invisible });
            AddItem(new Data() { DeciveName = "Shutdown", ImageId = Resource.Mipmap.Shutdown, ShowInfo = Android.Views.ViewStates.Invisible });
            AddItem(new Data() { DeciveName = "Sleep", ImageId = Resource.Mipmap.Shutdown, ShowInfo = Android.Views.ViewStates.Invisible });

            //Media
            AddItem(new Data() { DeciveName = "Play Previous", ImageId = Resource.Mipmap.ic_skip_previous, ShowInfo = Android.Views.ViewStates.Invisible });
            AddItem(new Data() { DeciveName = "Toggle Play", ImageId = Resource.Mipmap.ic_play_arrow, ShowInfo = Android.Views.ViewStates.Invisible });
            AddItem(new Data() { DeciveName = "Play Next", ImageId = Resource.Mipmap.ic_skip_next, ShowInfo = Android.Views.ViewStates.Invisible });

            //Volume
            AddItem(new Data() { DeciveName = "Volume Up", ImageId=Resource.Mipmap.Voulme_Up, ShowInfo = Android.Views.ViewStates.Invisible });
            AddItem(new Data() { DeciveName = "Volume Down", ImageId = Resource.Mipmap.voulme_down, ShowInfo = Android.Views.ViewStates.Invisible });
            AddItem(new Data() { DeciveName = "Mute", ImageId = Resource.Mipmap.Mute, ShowInfo = Android.Views.ViewStates.Invisible });

            //Message
            AddItem(new Data() { DeciveName = "Show Full Screen Text", ImageId = Resource.Mipmap.Message, ShowInfo = Android.Views.ViewStates.Invisible });
            AddItem(new Data() { DeciveName = "Show Full Screen Image", ImageId = Resource.Mipmap.Camera, ShowInfo = Android.Views.ViewStates.Invisible });
            AddItem(new Data() { DeciveName = "Close Shown", ImageId = Resource.Mipmap.Close, ShowInfo = Android.Views.ViewStates.Invisible });
         
           

        }
    }
}