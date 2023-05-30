using Plugin.PayCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using XamarinNativeDemo.Model;

namespace XamarinNativeDemo.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        #region [ Properties ]
        public string Homeimg = "iconHome.png";
        public string SelectedHomeimg = "iconBlueHome.png";
        public string Aboutimg = "iconAbout.png";
        public string SelectedAboutUsimg = "iconBlueAbout.png";
        public string Userimg = "iconBlackUser.png";
        public string SelectedUserimg = "iconBlueUser.png";
        public string Productimg = "iconProduct.png";
        public string SelectedProductimg = "iconBlueProduct.png";
        #endregion

        public MenuPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        public void ResetControls()
        {
            try
            {
                frmHome.BackgroundColor = Color.Transparent;
                imgHome.Source = Homeimg;
                lblHome.TextColor = Color.Black;

                FrmAbout.BackgroundColor = Color.Transparent;
                imgAbout.Source = Aboutimg;
                lblAbout.TextColor = Color.Black;

                frmUsers.BackgroundColor = Color.Transparent;
                imgUsers.Source = Userimg;
                lblUsers.TextColor = Color.Black;

                frmProducts.BackgroundColor = Color.Transparent;
                imgProducts.Source = Productimg;
                lblProducts.TextColor = Color.Black;

                frmCardScan.BackgroundColor = Color.Transparent;
                imgCardScan.Source = Productimg;
                lblCardScan.TextColor = Color.Black;

                frmScartchView.BackgroundColor = Color.Transparent;
                imgScratchView.Source = Productimg;
                lblScratchView.TextColor = Color.Black;

                frmContactShare.BackgroundColor = Color.Transparent;
                imgContactShare.Source = Productimg;
                lblContactShare.TextColor = Color.Black;

                frmTwoCardAnm.BackgroundColor = Color.Transparent;
                imgTwoCardAnm.Source = Productimg;
                lblTwoCardAnm.TextColor = Color.Black;

                frmCustomSlider.BackgroundColor = Color.Transparent;
                imgCustomSlider.Source = Productimg;
                lblCustomSlider.TextColor = Color.Black;

                frmCustomEntVal.BackgroundColor = Color.Transparent;
                imgCustomEntVal.Source = Productimg;
                lblCustomEntVal.TextColor = Color.Black;

                frmCstUIwithKeyboard.BackgroundColor = Color.Transparent;
                imgCstUIwithKeyboard.Source = Productimg;
                lblCstUIwithKeyboard.TextColor = Color.Black;

                frmEventWithTimer.BackgroundColor = Color.Transparent;
                imgEventWithTimer.Source = Productimg;
                lblEventWithTimer.TextColor = Color.Black;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void FrmHome_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmHome.BackgroundColor = Color.LightGray;
                imgHome.Source = SelectedHomeimg;
                lblHome.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new HomePage("Home"));
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void FrmAbout_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                FrmAbout.BackgroundColor = Color.LightGray;
                imgAbout.Source = SelectedAboutUsimg;
                lblAbout.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new HomePage("About Us"));
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void FrmUsers_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmUsers.BackgroundColor = Color.LightGray;
                imgUsers.Source = SelectedUserimg;
                lblUsers.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new HomePage("Users"));
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void FrmProducts_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmProducts.BackgroundColor = Color.LightGray;
                imgProducts.Source = SelectedProductimg;
                lblProducts.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new ProductPage());
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public void MenuOptionSelection(Frame selectedFrame)
        //{
        //    Image productImg = new Image();
        //    Label lbl = new Label();
        //    for(int i = 0; i <= grdMain.Children.Count; i++)
        //    {
        //        if (grdMain.Children[i] != null &&
        //            grdMain.Children[i] is Frame frmoption)
        //        {
        //            if (frmoption.Equals(selectedFrame))
        //            {
        //                frmoption.BackgroundColor = Color.FromHex("#A6000000");
        //                productImg = frmoption.Children[0] as Image;
        //                lbl = frmoption.Children[1] as Label;
        //                productImg = 
        //            }
        //            else
        //                frmoption.BackgroundColor = Color.Transparent;
        //        }
        //    }
        //}

        public void NavigatePage(Xamarin.Forms.Page page)
        {
            try
            {
                Model.Common.MasterPage.Detail = page;
                Model.Common.MasterPage.IsGestureEnabled = true;
                Model.Common.MasterPage.IsPresented = false;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void FrmStatusBG_Tapped(object sender, EventArgs e)
        {
            ResetControls();
            FrmStatusBG.BackgroundColor = Color.LightGray;
            imgStatusbar.Source = SelectedProductimg;
            lblStatusbar.TextColor = Color.FromHex("#0A7EF1");
            NavigatePage(new ChangeStatusbarBGPage());
        }

        private void FrmCardScan_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmCardScan.BackgroundColor = Color.LightGray;
                imgCardScan.Source = SelectedProductimg;
                lblCardScan.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new ScanCardDemo());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FrmScratchView_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmScartchView.BackgroundColor = Color.LightGray;
                imgScratchView.Source = SelectedHomeimg;
                lblScratchView.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new ScratchViewDemo());
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        private void FrmContactShare_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmContactShare.BackgroundColor = Color.LightGray;
                imgContactShare.Source = SelectedHomeimg;
                lblContactShare.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new ShareContactDemo());
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        private void FrmTwoCardAnm_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmTwoCardAnm.BackgroundColor = Color.LightGray;
                imgTwoCardAnm.Source = SelectedAboutUsimg;
                lblTwoCardAnm.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new TwoCardAnimationDemo());
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        private void FrmCustomSlider_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmCustomSlider.BackgroundColor = Color.LightGray;
                imgCustomSlider.Source = SelectedAboutUsimg;
                lblCustomSlider.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new RatingSwipeControlDemo());
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        private void FrmCustomEntVal_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmCustomEntVal.BackgroundColor = Color.LightGray;
                imgCustomEntVal.Source = SelectedAboutUsimg;
                lblCustomEntVal.TextColor = Color.FromHex("#0A7EF1");
                //NavigatePage(new CustomEntryValidationDemo());
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        private void frmCstUIwithKeyboard_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmCstUIwithKeyboard.BackgroundColor = Color.LightGray;
                imgCstUIwithKeyboard.Source = SelectedAboutUsimg;
                lblCstUIwithKeyboard.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new CustomizeUIwithKeyboard());
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }

        private void frmEventWithTimer_Tapped(object sender, EventArgs e)
        {
            try
            {
                ResetControls();
                frmEventWithTimer.BackgroundColor = Color.LightGray;
                imgEventWithTimer.Source = SelectedAboutUsimg;
                lblEventWithTimer.TextColor = Color.FromHex("#0A7EF1");
                NavigatePage(new EventWithTimerDemo());
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }
    }
}