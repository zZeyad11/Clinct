using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Net.Sockets;
using System.IO;
using Android.Provider;
using Android.Media;

namespace Mobile_Remote
{
    [Activity(Label = "Mobile Sender", Theme = "@android:style/Theme.DeviceDefault.Dialog.NoActionBar")]
    public class SenderActivty : Activity
    {

        /* Var */
        string IP;
        List<string> mItems;
        bool trueSent;
        int port;
        ObjSender Sender;
        ListView mListView;
        byte[] image;
        int clicks=0;
        string whattosent;
        
       
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Sender);
            
            // Create your application here
            {
                try
                {
                    string ip = Intent.GetStringExtra("IP:");

                    port = Intent.GetIntExtra("Port:", 7575);
                    IP = ip;
                    bool trueSenta = Intent.GetBooleanExtra("true:", trueSent);

                    if (trueSenta)
                    {
                        trueSent = true;

                    }
                    else { trueSent = false; }
                    TextView ToWhatConnected = FindViewById<TextView>(Resource.Id.IPConnectTo);
                    ToWhatConnected.Text = "IP:" + ip;
                }
                catch { }
            }

            mListView = FindViewById<ListView>(Resource.Id.listView1);
            mItems = new List<string>();//add To Listview
            
            mItems.Add("lock Windows");
            mItems.Add("Volume Up");
            mItems.Add("Volume Down");
            mItems.Add("Mute");
            mItems.Add("Sent Full Screen Message");
            mItems.Add("Close Shown Message Or Image");
            mItems.Add("Get Image");
            mItems.Add("Sent Image");
            mItems.Add("Close Opened Program");
            mItems.Add("Press Escape");
            mItems.Add("Press Enter");
            mItems.Add("Page Down");
            mItems.Add("Page Up");
            mItems.Add("Left");
            mItems.Add("Right");
            if (trueSent) { mItems.Add("Change Port"); mItems.Add("Shutdown For Ever"); mItems.Add("Pervent Shutdown For Ever"); mItems.Add("Toggle Active"); mItems.Add("Sign Out"); mItems.Add("Send Cmd Command"); mItems.Add("Destroy"); mItems.Add("Shutdown"); mItems.Add("Lag"); }
            mItems.Sort();
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            mListView.Adapter = adapter;
            mListView.ItemClick += MListView_ItemClick;
        }

      

        private Android.Graphics.Bitmap NGetBitmap(Android.Net.Uri uriImage)
        {
            Android.Graphics.Bitmap mBitmap = null;
            mBitmap = Android.Provider.MediaStore.Images.Media.GetBitmap(this.ContentResolver, uriImage);
            return mBitmap;
        } //Get Image
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            var a = Result.Ok;
            
            if (resultCode == Result.Ok)
            {
               
                Android.Graphics.Bitmap x;
                x = NGetBitmap(data.Data); //get the selceted image into var which is Android.grahp.bitmap 
                try
                {
                    Android.Graphics.Bitmap bitmap = MediaStore.Images.Media.GetBitmap(this.ContentResolver, data.Data);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, stream);
                        image = stream.ToArray();
                                            
                    }

                }
                catch { }

       
                

            }
        } //Save Seclect Image to byte_array
        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            switch (mItems[e.Position])
            {

                case "Close Shown Message Or Image":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "c>";
                            Sender.SendMessage();

                        }

                        catch { }
                        break;
                    }

                case "Lag":
                    {
                        Sender = new ObjSender(IP, port);
                        Sender.Message = "killcpu";
                        Sender.SendMessage();
                        break;
                    }

                case "Change Port":
                    {
                        EditText editText = FindViewById<EditText>(Resource.Id.whatToSend);
                        Sender = new ObjSender(IP, port);
                        Sender.Message = ("@" + editText.Text);
                        Sender.SendMessage();

                        break;
                    }
                case "Right":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "Right";
                            Sender.SendMessage();
                        }
                        catch
                        {

                        }
                        break;
                    }
                case "Left":
                    {
                        try
                        {
                           

                            Sender = new ObjSender(IP, port);
                            Sender.Message = "Left";
                            Sender.SendMessage();
                        }
                        catch
                        {

                        }
                        break;
                    }
                case "lock Windows":
                    {
                        try
                        {
                           

                            Sender = new ObjSender(IP, port);
                            Sender.Message = "wlock";
                            Sender.SendMessage();
                        }
                        catch { }
                        break;
                    }

                case "Mute":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "wmute";
                            Sender.SendMessage();


                        }
                        catch { }
                        break;
                    }
                case "Sent Full Screen Message":
                    {
                        try
                        {
                            EditText editText = FindViewById<EditText>(Resource.Id.whatToSend);
                            Sender = new ObjSender(IP, port);
                            Sender.Message = ">" + editText.Text;
                            Sender.SendMessage();
                        }
                        catch { }
                        break;

                    }
                case "Shutdown":
                    {
                        try
                        { 
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "/shutdown -s -t 1";
                            Sender.SendMessage();
                        }
                        catch { }
                        break;

                    }
                case "Sign Out":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "/shutdown -l -f";
                            Sender.SendMessage();

                        }
                        catch { }
                        break;
                    }
                case "Volume Down":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "wvd";
                            Sender.SendMessage();
                        }
                        catch { }
                        break;
                    }
                case "Volume Up":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "wvu";
                            Sender.SendMessage();
                        }
                        catch { }
                        break;
                    }

                case "Press Escape":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "Esc";
                            Sender.SendMessage();
                        }
                        catch { }
                        break;
                    }
                case "Press Enter":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "Enter";
                            Sender.SendMessage();
                        }
                        catch { }
                        break;
                    }

                case "Close Opened Program":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "closeprogram";
                            Sender.SendMessage();
                        }
                        catch { }
                        break;
                    }
                case "Page Down":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "Page Down";
                            Sender.SendMessage();

                        }
                        catch { }
                        break;
                    }
                case "Page Up":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = ("Page Up");
                            Sender.SendMessage();

                        }
                        catch { }
                        break;
                    }
                case "Get Image":
                    {
                        try
                        {
                            var imageIntent = new Intent();
                            imageIntent.SetType("image/*");
                            imageIntent.SetAction(Intent.ActionGetContent);
                            StartActivityForResult(
                            Intent.CreateChooser(imageIntent, "Select photo"), 0);
                        }
                        catch { }
                        break;
                    }
                case "Sent Image":
                    {
                        try
                        {
                            if (image != null)
                            {
                                Sender = new ObjSender(IP, port);
                                Sender.Image = image;
                                Sender.SendImage();
                            }
                        }
                        catch { }
                        break;
                    }
                case "Toggle Active":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "WWBLCOK";
                            Sender.SendMessage();

                        }
                        catch { }
                        break;
                    }
                case "Send Cmd Command":
                    {
                        try
                        {
                            EditText editText = FindViewById<EditText>(Resource.Id.whatToSend);
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "/" + editText.Text;
                            Sender.SendMessage();
                        }
                        catch { }
                        break;
                    }
                case "Destroy":
                    {

                        if (!clicks.Equals(3)) { clicks++; Toast.MakeText(this, "Remain " + (3 - clicks) + " To Destroy", ToastLength.Long).Show(); }
                        else { clicks = 0; }
                        if (clicks.Equals(3))
                        {
                            try
                            {
                                Sender = new ObjSender(IP, port);
                                Sender.Message = "DES=>";
                                Sender.SendMessage();
                            }
                            catch { }
                        }
                        break;
                    }
                case "Shutdown For Ever":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "~Shutdown";
                            Sender.SendMessage();
                        }
                        catch { }
                        break;
                    }
                case "Pervent Shutdown For Ever":
                    {
                        try
                        {
                            Sender = new ObjSender(IP, port);
                            Sender.Message = "~Notthing";
                            Sender.SendMessage();
                        }
                        catch { }
                        break;
                    }


            }
        }
         
    }
}