using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNativeDemo.DependencyServices;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeStatusbarBGPage : ContentPage
    {
        public ChangeStatusbarBGPage()
        {
            InitializeComponent();
        }

        private void FrmShowStatusbar_Tapped(object sender, EventArgs e)
        {
            DependencyService.Get<IStatusBar>().ShowStatusBar();
        }

        private void FrmHideStatusbar_Tapped(object sender, EventArgs e)
        {
            DependencyService.Get<IStatusBar>().HideStatusBar();
        }
    }
}