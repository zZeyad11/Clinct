using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeyadRemoteControl.Events.Args
{
    public class NewIpFoundEvent : EventArgs
    {
        public String IP;
        public int Persent;
    }


    public class FastScanNewIpFoundEvent : EventArgs
    {
        public String IP;
    }
    public class RecivedObjectEvent : EventArgs
    {
        public object Obj;
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

    public class RecivedFinshed : EventArgs
    {

        public Image Image;
    }
}
