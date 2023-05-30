using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinNativeDemo.Model
{
    public class PermissionInfo : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

        public bool isGranted;
        public bool IsGranted
        {
            get { return isGranted; }
            set {
                isGranted = value;
                OnPropertyChanged();
            }
        }
        public Xamarin.Essentials.Permissions.BasePermission Permission { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
