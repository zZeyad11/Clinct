using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using RemoteSender;

namespace Remote_Sender
{
    [Activity( MainLauncher = true, Theme = "@style/Theme.DesignDemo", NoHistory =true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Splash : Activity
    {
        protected override void OnResume()
        {
            base.OnResume();
            SetContentView(Resource.Layout.Splash);
            Task StartupWork = new Task(() => { Task.Delay(6000); });
            StartupWork.ContinueWith(t => { StartActivity(new Intent(Application.Context, typeof(MainActivity))); }, TaskScheduler.FromCurrentSynchronizationContext());
            StartupWork.Start();
        }
    }
}