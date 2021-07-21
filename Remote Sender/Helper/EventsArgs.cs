using Android.Graphics;
using System;

namespace ZeyadRemoteControl.Events.Args
{
    public class NewIpFoundEvent : EventArgs
    {
        public String IP;
        public int Persent;
    }

    public class RecivedObjectEvent : EventArgs
    {
        public object Obj;
    }
    public class RecivedFinshed : EventArgs
    {

        public Bitmap Image;
    }
    public class FastScanNewIpFoundEvent : EventArgs
    {
        public String IP;
    }
    public class FinshedScaning : EventArgs
    {

    }
    public class UpdateEvent : EventArgs
    {
        public int Persent;
        public string IP;
    }

    public class FastScanUpdateEvent : EventArgs
    {
        public int Persent;
    }


}
