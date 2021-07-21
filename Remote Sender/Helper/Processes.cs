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
   public class Processes
    {
        public string Description;
        public string ProcessID;
        public string ProcessName;
        public string ProcessPath;
        public string ProcessVoulme;
        public string AppTitle;
      public Processes(string Info)
        {
            Description = Info.Split(Char.Parse("|"))[0];
            ProcessID = Info.Split(Char.Parse("|"))[1];
            ProcessName = Info.Split(Char.Parse("|"))[2];
            ProcessVoulme = Info.Split(Char.Parse("|"))[3];
            ProcessPath= Info.Split(Char.Parse("|"))[4];
         //   AppTitle = Info.Split(Char.Parse("|"))[5];

        }

    }
}