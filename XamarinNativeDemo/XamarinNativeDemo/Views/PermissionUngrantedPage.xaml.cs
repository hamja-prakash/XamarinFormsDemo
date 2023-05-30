using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNativeDemo.ViewModels;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PermissionUngrantedPage : ContentPage
	{
		public PermissionUngrantedPage ()
		{
			InitializeComponent ();
			this.BindingContext = new PermissionUngrantedPageViewModel();
		}
	}
}