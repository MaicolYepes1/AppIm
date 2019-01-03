namespace AppIm.Droid
{
    using Android.App;
    using Android.OS;

    [Activity(Label = "AppIm", Icon = "@mipmap/icon",
              //Theme = "@style/MainTheme",
              Theme = "@style/Theme.Splash",
              MainLauncher = true,
              NoHistory = true)]
    public class ActivitySplash : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(2000);
            this.StartActivity(typeof(MainActivity));
            // Create your application here
        }
    }
}