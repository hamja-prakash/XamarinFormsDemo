using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNativeDemo.API;
using XamarinNativeDemo.DependencyServices;
using XamarinNativeDemo.Model;
using Newtonsoft.Json;
using static XamarinNativeDemo.Views.HomePage;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        #region [ Properties ]
        public string HomeImg = "iconHome.png";
        public string AboutImg = "iconAbout.png";
        public string UserImg = "iconBlackUser.png";
        public string WhiteHomeImg = "iconBlueHome.png";
        public string WhiteAboutImg = "iconBlueAbout.png";
        public string WhiteUserImg = "iconBlueUser.png";
        #endregion

        public HomePage(string page)
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            UpdateUI(page);
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        #region [ Methods ]
        public void UpdateUI(string pageName)
        {
            try
            {
                grdMain.Children.Clear();
                ResetControls();
                lblHeader.Text = pageName;
                if (pageName == "Home")
                {
                    imgHome.Source = WhiteHomeImg;
                    lblHome.TextColor = Color.FromHex("#0A7EF1");
                    var homeview = new HomeView();
                    homeview.BindHomeData();
                    grdMain.Children.Add(homeview);
                }
                else if (pageName == "About Us")
                {
                    imgAbout.Source = WhiteAboutImg;
                    lblAbout.TextColor = Color.FromHex("#0A7EF1");
                    var aboutusview = new AboutUsView();
                    grdMain.Children.Add(aboutusview);
                }
                else if (pageName == "Users")
                {
                    imgUser.Source = WhiteUserImg;
                    lblUser.TextColor = Color.FromHex("#0A7EF1");
                    var userView = new UserView(imgMenu, lblHeader);
                    //userview.refreshEvent += (s1, e1) =>
                    //{
                    //    var isRefresh = (bool)s1;
                    //    if(isRefresh)
                    //        grdMain.Children.Add(userview);
                    //};
                    grdMain.Children.Add(userView);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public void ResetControls()
        {
            try
            {
                imgHome.Source = HomeImg;
                lblHome.TextColor = Color.Black;
                imgAbout.Source = AboutImg;
                lblAbout.TextColor = Color.Black;
                imgUser.Source = UserImg;
                lblUser.TextColor = Color.Black;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        #region [ Events ] 
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(lblHeader.Text.Equals("Add User"))
                {
                    grdMain.Children.Clear();
                    lblHeader.Text = "Users";
                    imgMenu.Source = "iconWhiteMenu.png";
                    grdMain.Children.Add(new UserView(imgMenu, lblHeader));
                }
                else
                {
                    Model.Common.MasterPage.IsGestureEnabled = false;
                    Model.Common.MasterPage.IsPresented = true;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void stkHome_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                UpdateUI(lblHome.Text);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void stkAbout_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                UpdateUI(lblAbout.Text);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void stkTest_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                UpdateUI(lblUser.Text);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void stkTest1_Tapped(object sender, EventArgs e)
        {

        }
        #endregion

        //public async Task GetEmployeeData()
        //{
        //    try
        //    {
        //        EmployeeAPIs employeeAPIs = new EmployeeAPIs();
        //        var employeeResult = await employeeAPIs.GetEmployees();
        //        if (employeeResult != null)
        //        {
        //            var mlist = employeeResult;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var msg = ex.Message;
        //    }
        //}

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert("Alert!", "Do you really want to exit the application?", "Yes", "No");
                if (result)
                {
                    if (Device.OS == TargetPlatform.Android)
                        DependencyService.Get<IAndroidMethods>().CloseApp();
                }
            });
            return true;
        }
    }
}