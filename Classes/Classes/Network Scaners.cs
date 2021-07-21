using System;
using System.Collections.Generic;
using System.Linq;
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

        public  FastNetworkScaner(int v)
        {
            Thread thread = new Thread(delegate () { InitializeScaners(v); });
            thread.Start();
        }
        public static string GetMachineName(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);
                machineName = hostEntry.HostName;
                return machineName;
            }
            catch
            {
                return ipAdress;
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
                Scaners.Add(new NetworkScaner(Start, End));
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
                    if(Persent >= 100)
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

        public FastPortNetworkScaner(int v,int port)
        {
            InitializeScaners(v);
            this.Port = port;
        }
        public static string GetMachineName(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);
                machineName = hostEntry.HostName;
                return machineName;
            }
            catch
            {
                return ipAdress;
            }

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
                Scaners.Add(new NetworkScaner(Start, End));
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
                    Persent = (Persent / (v * 100));
                    Persent *= 100;
                    if (Persent >= 100)
                    {
                        Persent = 100;
                        Finshed(this, new FinshedScaning());
                        Dispose();
                    }
                    fastScan.Persent = (int)Persent;
                    Update(this, fastScan);

                };

            }
        }

        public void Dispose()
        {
            foreach(var i in Scaners)
            {
                i.End();
            }
        }

    }
    public class NetworkScaner

    {
        public static string GetDefaultGateway()
        {
            IPAddress IP;
            try
            {
                IP = NetworkInterface
                   .GetAllNetworkInterfaces()
                   .Where(n => n.OperationalStatus == OperationalStatus.Up)
                   .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                   .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                   .Select(g => g?.Address)
                   .Where(a => a != null)
                   // .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                   // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
                   .FirstOrDefault();
            }

            catch
            {
                IP = IPAddress.Parse("192.168.1.1");
            }

            if (IP == null) { IP = IPAddress.Parse("192.168.1.1"); }
            return IP.ToString();
        }
        private Thread scanthread;
        private int start;
        private int end;
        public event NewIpFound FoundIP;
        public event ScanFinshed FinshedScan;
        public event Update Updator;
        public bool Finshed;
        private static List<NetworkScaner> NetworkScaners = new List<NetworkScaner>();
        private static bool PingHost(string nameOrAddress)
        {
            var pingSender = new Ping();
            PingReply reply = pingSender.Send(nameOrAddress, 20);

            if (reply.Status == IPStatus.Success) { return true; }
            else { return false; }
        }

        public NetworkScaner(int start, int end)
        {
            NetworkScaner.NetworkScaners.Add(this);
            this.start = start;
            this.end = end;
        }

        public static List<NetworkScaner> GetNetworkScaners()
        {
            return NetworkScaners;
        }
        ~NetworkScaner()
        {
            NetworkScaner.NetworkScaners.Remove(this);
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
                    var z = GetDefaultGateway().ToString();
                    var split = z.Split(char.Parse("."));
                    var ip = split[0] + "." + split[1] + "." + split[2] + ".";
                    y = ip + x;
                    Persent = (int)((x * 100) / end);
                    if(Persent > 100) { Persent = 100; }
                    updateEvent.Persent = Persent;
                    updateEvent.IP = y;
                    e.Persent = Persent;
                    Updator(this, updateEvent);
                    if (PingHost(y) && y != GetDefaultGateway().ToString())
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

        public void End()
        {
            try
            {
                GC.SuppressFinalize(this);
                
            }
            catch
            {

            }
           
        }


    }
    public class PortNetworkScaner

    {
        public static string GetDefaultGateway()
        {
            IPAddress IP;
            try
            {
                 IP = NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up)
                    .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                    .Select(g => g?.Address)
                    .Where(a => a != null)
                    // .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                    // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
                    .FirstOrDefault();
            }

            catch
            {
                IP = IPAddress.Parse("192.168.1.1");
            }

            if (IP == null) { IP = IPAddress.Parse("192.168.1.1"); }
            return IP.ToString();
        }
        private Thread scanthread;
        private int start;
        private int end;
        private int Port;

        public event NewIpFound FoundIP;
        public event ScanFinshed FinshedScan;
        public event Update Updator;
        public bool Finshed;
        private static List<PortNetworkScaner> NetworkScaners = new List<PortNetworkScaner>();
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
            this.start = start;
            this.end = end;
            this.Port = port;
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
        public List<string> IPS = new List<string>();
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
                    var z = GetDefaultGateway().ToString();
                    var split = z.Split(char.Parse("."));
                    var ip = split[0] + "." + split[1] + "." + split[2] + ".";
                    y = ip + x;
                    Persent = (int)((x * 100) / end);
                    if (Persent > 100) { Persent = 100; }
                    updateEvent.Persent = Persent;
                    updateEvent.IP = y;
                    e.Persent = Persent;
                    Updator(this, updateEvent);
                    if (PingHost(y) && y != GetDefaultGateway().ToString() && IsPortOpen(y,Port) )
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
