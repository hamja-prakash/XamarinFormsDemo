using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinNativeDemo.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPopupPage : PopupPage
    {
        public event EventHandler isRefresh;
       
        public AddProductPopupPage(string name)
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = false;
            lblName.Text = name +" test";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (isRefresh != null)
                isRefresh.Invoke(lblName.Text, new EventArgs());
            PopupNavigation.PopAsync(true);
        }
    }
}