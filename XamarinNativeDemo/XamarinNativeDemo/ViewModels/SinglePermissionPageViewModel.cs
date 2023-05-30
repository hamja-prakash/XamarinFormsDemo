using MvvmHelpers.Commands;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace XamarinNativeDemo.ViewModels
{
    public class SinglePermissionPageViewModel
    {
        public ICommand GoHomeCommand { get; set; }
        public SinglePermissionPageViewModel()
        {
            GoHomeCommand = new Command(async () => await RequestPermissionAsync());
        }

        async Task RequestPermissionAsync()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            await App.Current.MainPage.Navigation.PushAsync(Model.Common.MasterPage);
        }
    }
}
