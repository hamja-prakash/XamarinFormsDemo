using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinNativeDemo.DependencyServices;
using XamarinNativeDemo.Droid.Dependencies;

[assembly: Dependency(typeof(AndroidMethods))]

namespace XamarinNativeDemo.Droid.Dependencies
{
    public class AndroidMethods : IAndroidMethods
    {
        [System.Obsolete]
        public void CloseApp()
        {
            //var activity = new Activity();
            //activity.FinishAffinity();
           Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}