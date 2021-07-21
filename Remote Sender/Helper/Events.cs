using ZeyadRemoteControl.Events.Args;

namespace ZeyadRemoteControl.Events
{
    public delegate void NewIpFound(object sender, NewIpFoundEvent IP);
    public delegate void FastScanNewIpFound(object sender, FastScanNewIpFoundEvent IP);
    public delegate void FastScanUpdateEventHandler(object sender, FastScanUpdateEvent IP);
    public delegate void Update(object sender, UpdateEvent update);
    public delegate void ScanFinshed(object sender, FinshedScaning e);
    public delegate void RecivedObject(object sender, RecivedObjectEvent update);
    public delegate void Recived(object sender, RecivedFinshed e);
    public delegate void Failure(object sender);
}
