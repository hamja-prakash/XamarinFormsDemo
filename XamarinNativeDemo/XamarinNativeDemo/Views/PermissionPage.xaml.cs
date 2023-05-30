using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNativeDemo.ViewModels;

namespace XamarinNativeDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PermissionPage : ContentPage
	{
		public PermissionPage ()
		{
			InitializeComponent ();
			this.BindingContext = new PermissionPageViewModel();
		}
	}
}