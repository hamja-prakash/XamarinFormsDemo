using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Essentials.Permissions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using XamarinNativeDemo.Model;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace XamarinNativeDemo.ViewModels
{
    public class PermissionPageViewModel : INotifyPropertyChanged
    {
        public ICommand OnSelectPermissionChangeCommand { get; set; }
        public ICommand GoHomeCommand { get; set; }

        public bool _isVisible;
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }
        

        public int PermissionGrantedCount { get; set; }

        public ICommand LoadPermissionCommand { get; set; }
        public List<PermissionInfo> PermissionsList { get; set; }
        public PermissionInfo PermissionSelected { get; set; }

        public PermissionPageViewModel()
        {
            IsVisible = false;
            PermissionSelected = new PermissionInfo();
            LoadPermissionCommand = new Command(async () => await LoadPermissions());
            LoadPermissionCommand.Execute(null);
            //CheckGrantedPermission(PermissionSelected);
            OnSelectPermissionChangeCommand = new Command<PermissionInfo>(CheckPermission);

            GoHomeCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(Model.Common.MasterPage);
            });
        }

        public async void CheckPermission(PermissionInfo permission)
        {
            if (permission != null)
            {
                permission.IsGranted = await CheckAndRequestPermissionAsync(permission.Permission) == PermissionStatus.Granted;

                CheckGrantedPermission(permission);
                //var per = await CheckAndRequestPermissionAsync(permission.Permission);
                //if (per == PermissionStatus.Granted)
                //{
                //    PermissionGrantedCount = 0;
                //    permission.IsGranted = true;
                //    foreach (var item in PermissionsList)
                //    {
                //        if (item.IsGranted)
                //            PermissionGrantedCount += 1;
                //    }
                //    if (PermissionGrantedCount == PermissionsList.Count)
                //        IsVisible = true;
                //    else
                //        IsVisible = false;
                //}
            }
        }

        public async void CheckGrantedPermission(PermissionInfo permission)
        {
            try
            {
                var per = await CheckAndRequestPermissionAsync(permission.Permission);
                if (per == PermissionStatus.Granted)
                {
                    PermissionGrantedCount = 0;
                    permission.IsGranted = true;
                    foreach (var item in PermissionsList)
                    {
                        if (item.IsGranted)
                            PermissionGrantedCount += 1;
                    }
                    if (PermissionGrantedCount == PermissionsList.Count)
                        IsVisible = true;
                    else
                        IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        async Task LoadPermissions()
        {
            PermissionsList = new List<PermissionInfo>()
            {
                { await CreatePermission(new Camera(), "Camera.png", "Camera", "So your friends can see you")},
                { await CreatePermission(new Microphone(), "Microphone.png", "Microphone", "So your friends can hear you") },
                { await CreatePermission(new LocationWhenInUse(), "Location.png", "Location", "So your friends can find you") }
            };
        }

        async Task<PermissionInfo> CreatePermission(BasePermission permission, string icon, string name, string description)
        {
            return new PermissionInfo()
            {
                Icon = icon,
                Permission = permission,
                Name = name,
                Description = description,
                IsGranted = await permission.CheckStatusAsync() == PermissionStatus.Granted
            };
        }

        async Task<PermissionStatus> CheckAndRequestPermissionAsync(BasePermission permission)
        {
            var status = await permission.CheckStatusAsync();
            if (status != PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }
            return status;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
