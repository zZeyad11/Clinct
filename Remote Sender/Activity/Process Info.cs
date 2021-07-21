using Android.Support.V7.App;
using Android.App;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Views;
using Android.Gms.Ads;
using System;
using RemoteSender;

namespace Remote_Sender
{
    [Activity(Label = "Process Info", Theme = "@style/Theme.DesignDemo", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Process_Info : AppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProcessInfo);
            SetActionBarView();




        }


        private void SetActionBarView()
        {
            SupportToolbar toolbar = FindViewById<SupportToolbar>(Resource.Id.toolBar1);
            SetSupportActionBar(toolbar);
            SupportActionBar ab = SupportActionBar;
            SupportActionBar.Title = "Processs Info";
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


    }
}