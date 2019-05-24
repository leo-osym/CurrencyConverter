using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using CurrencyConverter.Droid.FlagList;

namespace CurrencyConverter.Droid.Activities
{
    [Activity(MainLauncher = true,Theme ="@style/MyTheme.Splash",NoHistory = true, 
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    class ActivitySplash :AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(ActivitySplash).Name;
        protected override void OnCreate(Bundle savedInstanceState)

        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_splash_screen);
            FlagsDictionary.InitDictionary();
        }
        
            protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        
        async void SimulateStartup()
        {
            Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
            await Task.Delay(3000); 
            Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }

}