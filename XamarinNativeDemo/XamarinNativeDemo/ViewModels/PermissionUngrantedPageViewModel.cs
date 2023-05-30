using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace XamarinNativeDemo.ViewModels
{
    public class PermissionUngrantedPageViewModel
    {
        public ICommand GoSettingsCommand { get; set; }
        public PermissionUngrantedPageViewModel()
        {
            GoSettingsCommand = new Command(() => AppInfo.ShowSettingsUI());
        }
    }
}
