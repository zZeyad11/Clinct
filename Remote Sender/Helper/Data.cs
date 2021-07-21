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

namespace Remote_Sender.Helper
{
    class Data
    {
        public int ImageId { get; set; }
        public String DeciveName { get; set; }
        public String IP { get; set; }
        public int InfoImageId { get; set; }
        public Android.Views.ViewStates ShowInfo { get; set; }
    }
}