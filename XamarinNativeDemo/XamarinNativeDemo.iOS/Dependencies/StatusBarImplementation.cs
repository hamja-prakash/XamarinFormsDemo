using UIKit;
using Xamarin.Forms;
using XamarinNativeDemo.DependencyServices;
using XamarinNativeDemo.iOS.Dependencies;

[assembly: Dependency(typeof(StatusBarImplementation))]

namespace XamarinNativeDemo.iOS.Dependencies
{
    public class StatusBarImplementation : IStatusBar
    {
        public StatusBarImplementation()
        {
        }

        #region IStatusBar implementation

        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }

        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }

        #endregion
    }
}