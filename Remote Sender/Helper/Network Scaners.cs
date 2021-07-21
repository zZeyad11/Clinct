using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using ZeyadRemoteControl.Events;
using ZeyadRemoteControl.Events.Args;

namespace ZeyadRemoteControl.NetworkScaners
{
    public class FastNetworkScaner
    {
        List<NetworkScaner> Scaners = new List<NetworkScaner>();
        public event FastScanNewIpFound NewIpFound;
        public event FastScanUpdateEventHandler Update;
        public event ScanFinshed Finshed;
        private string GateWayIpAddress;
        public  FastNetworkScaner(int v, string GateWayIpAddress)
        {
            this.GateWayIpAddress = GateWayIpAddress;
            InitializeScaners(v);
          


        }
        public static string GetMachineName(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);
                machineName = hostEntry.HostName;
                if (machineName != ipAdress)
                {
                    return machineName;
                }
                else
                {
                    return "Unknown";
                }
            }
            catch
            {
                return "Unknown";
            }

        }

        public void RunScan()
        {
           
            StartScan();
        }

        private void StartScan()
        {
            foreach (NetworkScaner a in Scaners)
            {
                a.Scan();
            }
        }

        private void InitializeScaners(int v)
        {
            ZeyadRemoteControl.Events.Args.FastScanUpdateEvent fastScan = new FastScanUpdateEvent();
            for (int x = 0; x <= v; x++)
            {
                int Start = (256 / v) * (x);
                int End = ((256 / v) * (x + 1)) - 1;
                if (End > 256) { End = 256; }
                Scaners.Add(new NetworkScaner(Start, End,GateWayIpAddress));
            }
            foreach (NetworkScaner a in Scaners)
            {

                a.FoundIP += (s, e) =>
                {
                    Events.Args.FastScanNewIpFoundEvent ipFoundEvent = new FastScanNewIpFoundEvent();
                    ipFoundEvent.IP = e.IP;
                    NewIpFound(this, ipFoundEvent);
                };

                a.Updator += (s, e) =>
                {
                    
                    double Persent = 0;

                    foreach (var y in Scaners)
                    {
                        Persent += y.Persent;
                    }
                    Persent = (Persent/(v*100));
                    Persent *= 100;
                   
                    int count = 0;
                    foreach(var sc in Scaners)
                    {
                        if (sc.Finshed)
                        {
                            count++;
                        }
                    }
                    if (Persent > 90 && count <v)
                    {
                        Persent = 95;

                    }
                    if (count == v)
                    {
                        Persent = 100;
                        Finshed(this, new FinshedScaning());
                    }
                    fastScan.Persent = (int)Persent;
                    Update(this, fastScan);

                };

            }
        }

    }
    public class FastPortNetworkScaner
    {
        List<NetworkScaner> Scaners = new List<NetworkScaner>();
        private int Port;

        public event FastScanNewIpFound NewIpFound;
        public event FastScanUpdateEventHandler Update;
        public event ScanFinshed Finshed;
        private string GateWayIpAddress;


        public FastPortNetworkScaner(int v,int port, string GateWayIpAddress)
        {
            this.Port = port;
            this.GateWayIpAddress = GateWayIpAddress;
            InitializeScaners(v);
          
        }

        public static bool IsPortOpen(string host, int port)
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
        public void StartScan()
        {
            foreach (NetworkScaner a in Scaners)
            {
                a.Scan();
            }
        }

        public void StopScan()
        {
            try
            {
                foreach (NetworkScaner a in Scaners)
                {
                    a.Stop();
                    a.Equals(null);
                }
            }
            catch
            {

               
            }
        } 

        private void InitializeScaners(int v)
        {
            ZeyadRemoteControl.Events.Args.FastScanUpdateEvent fastScan = new FastScanUpdateEvent();
            for (int x = 0; x < v; x++)
            {
                int Start = (256 / v) * (x);
                int End = ((256 / v) * (x + 1)) - 1;
                if (End > 256) { End = 256; }
                Scaners.Add(new NetworkScaner(Start, End, GateWayIpAddress));
            }
            foreach (NetworkScaner a in Scaners)
            {

                a.FoundIP += (s, e) =>
                {
                    if (IsPortOpen(e.IP, Port))
                    {
                        Events.Args.FastScanNewIpFoundEvent ipFoundEvent = new FastScanNewIpFoundEvent();
                        ipFoundEvent.IP = e.IP;
                        NewIpFound(this, ipFoundEvent);
                    }

                };

                a.Updator += (s, e) =>
                {

                    double Persent = 0;

                    foreach (var y in Scaners)
                    {
                        Persent += y.Persent;
                    }
                    Persent = (Persent / ((v) * 100));
                    Persent *= 100;
                    if (Persent >= 100)
                    {
                        Persent = 100;
                        Finshed(this, new FinshedScaning());
                    }
                    fastScan.Persent = (int)Persent;
                    Update(this, fastScan);

                };

            }
        }

    }
    public class NetworkScaner

    {
        private Thread scanthread;
        private int start;
        private int end;
        public event NewIpFound FoundIP;
        public event ScanFinshed FinshedScan;
        public event Update Updator;
        public bool Finshed;
        private static List<NetworkScaner> NetworkScaners = new List<NetworkScaner>();
        private string GetwayIpAddress;
        private static bool PingHost(string nameOrAddress)
        {
            var pingSender = new Ping();
            PingReply reply = pingSender.Send(nameOrAddress, 20);

            if (reply.Status == IPStatus.Success) { return true; }
            else { return false; }
        }

        public NetworkScaner(int start, int end,string GatewayIpAddress)
        {
            GetwayIpAddress = GatewayIpAddress;
            NetworkScaners.Add(this);
            this.start = start;
            this.end = end;
           
        }

        public static List<NetworkScaner> GetNetworkScaners()
        {
            return NetworkScaners;
        }
        ~NetworkScaner()
        {
            NetworkScaners.Remove(this);
        }

        public void Scan()
        {
            scanthread = new Thread(scan);
            scanthread.Start();
        }
        public List<string> IPS = new List<string>();
        public int Persent { get; set; }
        private void scan()
        {
            NewIpFoundEvent e = new NewIpFoundEvent();
            UpdateEvent updateEvent = new UpdateEvent();
            FinshedScaning finshed = new FinshedScaning();
            for (int x = start; x <= end; x++)
            {
                try
                {
                    string y;
                    y = null;
                    var z = GetwayIpAddress;
                    var split = z.Split(char.Parse("."));
                    var ip = split[0] + "." + split[1] + "." + split[2] + ".";
                    y = ip + x;
                    Persent = (int)((x * 100) / end);
                    if(Persent > 100) { Persent = 100; }
                    updateEvent.Persent = Persent;
                    updateEvent.IP = y;
                    e.Persent = Persent;
                    Updator(this, updateEvent);
                    if (PingHost(y) && y != GetwayIpAddress)
                    {
                        IPS.Add(y);
                        e.IP = y;
                        FoundIP(this, e);

                    }

                }
                catch
                {


                }
            }
            try
            {
                Finshed = true;
                FinshedScan(this, finshed);
            }
            catch { }

        }

        public void Stop()
        {
            scanthread.Abort();
        }


    }
    public class PortNetworkScaner

    {
        private Thread scanthread;
        private int start;
        private int end;
        private int Port;
        private static List<PortNetworkScaner> NetworkScaners = new List<PortNetworkScaner>();
        private string GetwayIpAddress;

        public event NewIpFound FoundIP;
        public event ScanFinshed FinshedScan;
        public event Update Updator;
        public bool Finshed;
        public List<string> IPS = new List<string>();
        private static bool PingHost(string nameOrAddress)
        {
            var pingSender = new Ping();
            PingReply reply = pingSender.Send(nameOrAddress, 20);

            if (reply.Status == IPStatus.Success) { return true; }
            else { return false; }
        }

        public PortNetworkScaner(int start, int end, int port)
        {
            PortNetworkScaner.NetworkScaners.Add(this);
            this.Port = port;
            this.start = start;
            this.end = end;
          
        }

        public static List<PortNetworkScaner> GetNetworkScaners()
        {
            return NetworkScaners;
        }
        ~PortNetworkScaner()
        {
            PortNetworkScaner.NetworkScaners.Remove(this);
        }

        public void Scan()
        {
            scanthread = new Thread(scan);
            scanthread.Start();
        }
       

        public int Persent { get; set; }
        public static bool IsPortOpen(string host, int port)
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
        private void scan()
        {
            NewIpFoundEvent e = new NewIpFoundEvent();
            UpdateEvent updateEvent = new UpdateEvent();
            FinshedScaning finshed = new FinshedScaning();
            for (int x = start; x <= end; x++)
            {
                try
                {
                    string y;
                    y = null;
                    var z = GetwayIpAddress;
                    var split = z.Split(char.Parse("."));
                    var ip = split[0] + "." + split[1] + "." + split[2] + ".";
                    y = ip + x;
                    Persent = (int)((x * 100) / end);
                    if (Persent > 100) { Persent = 100; }
                    updateEvent.Persent = Persent;
                    updateEvent.IP = y;
                    e.Persent = Persent;
                    Updator(this, updateEvent);
                    if (PingHost(y) && y != GetwayIpAddress && IsPortOpen(y,Port) )
                    {
                        IPS.Add(y);
                        e.IP = y;
                        FoundIP(this, e);

                    }

                }
                catch
                {


                }
            }
            try
            {
                Finshed = true;
                FinshedScan(this, finshed);
            }
            catch { }

        }


    }



}
