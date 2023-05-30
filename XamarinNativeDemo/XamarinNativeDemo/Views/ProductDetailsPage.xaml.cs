using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNativeDemo.API;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailsPage : ContentPage
	{
		public int productId = 0;
		public ProductAPI productAPI;

		public ProductDetailsPage (int productid)
		{
			InitializeComponent ();
            productAPI = new ProductAPI ();
            this.productId = productid;
			//lblTotal.Text = grdStepper.Text.ToString();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
			await GetProductDetails(this.productId);
        }

        public async Task GetProductDetails(int Id)
        {
            try
			{
                ShowLoader(true);
                var productDetailsResult = await productAPI.ProductDetailsByProductId(Id);
				if (productDetailsResult != null)
				{
                    grdmain.IsVisible= true;
                    ShowLoader(false);
					txtProductName.Text = productDetailsResult.title;
                    imgProduct.Source = productDetailsResult.image;
					lblPrice.Text = "$ " + productDetailsResult.price.ToString();
                    txtProductDesc.Text = productDetailsResult.description;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public void ShowLoader(bool isLoad)
        {
            try
            {
                grdloader.IsVisible = isLoad;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void imgBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void FrmAddcart_Tapped(object sender, EventArgs e)
        {
			try
			{
				await FrmAddcart.ScaleTo(0.9, 100, Easing.Linear);
				await FrmAddcart.ScaleTo(1.0, 100, Easing.Linear);
            }
			catch (Exception)
			{
				throw;
			}
        }
    }
}