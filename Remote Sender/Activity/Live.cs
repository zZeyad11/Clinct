using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remote_Sender.Helper;
using RemoteSender;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Remote_Sender.Recivers;
using ZeyadRemoteControl.Events.Args;
using Android.Graphics;
using System.IO;

namespace RemoteSender
{
    [Activity(Label = "Remote", Theme = "@style/Theme.DesignDemo", ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    public class Live : AppCompatActivity
    {
        ImageReciver reciver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Live);

            ((ImageView)FindViewById(Resource.Id.RecivedImage)).SetImageBitmap(BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.noFeed));
            SetImageReciver();
            SetActionBarView();
            
        }

        private void SetImageReciver()
        {
            reciver = new ImageReciver(2001);
            reciver.Update += Reciver_Update;
            reciver.Start();
        }

        private void Reciver_Update(object sender, RecivedFinshed e)
        {
                var Image = e.Image;
                if (Image != null)
                {
                ((ImageView)FindViewById(Resource.Id.RecivedImage)).SetImageBitmap(Image);               
                }

        }
        private void SetActionBarView()
        {
            SupportToolbar toolbar = FindViewById<SupportToolbar>(Resource.Id.toolBar2);
            SetSupportActionBar(toolbar);
            SupportActionBar ab = SupportActionBar;
            SupportActionBar.Title = "Live";
            ab.SetHomeAsUpIndicator(Resource.Mipmap.ic_keyboard_backspace);
            ab.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            reciver.Stop();
            base.OnBackPressed();
            
        }
        public override void Finish()
        {
            reciver.Stop();
            base.Finish();
            
        }
    }
}