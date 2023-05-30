using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNativeDemo.API;
using XamarinNativeDemo.Model;
using XamarinNativeDemo.Model.Product;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ProductAPI productAPI;
        public ObservableCollection<Grouping<string, Product>> mProducts;

        public ProductPage()
        {
            InitializeComponent();
            productAPI = new ProductAPI();
            mProducts = new ObservableCollection<Grouping<string, Product>>();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await BindAllProducts();
        }

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    Home?.OnDisappearing();
        //}

        public async Task BindAllProducts()
        {
            try
            {
                ShowLoader(true);
                var productResult = await productAPI.GetProducts();
                if (productResult != null && productResult.Count > 0)
                {
                    ShowLoader(false);
                    var items = from item in productResult
                                orderby
                                item.category
                                group item by item.category.ToUpper().ToString() into categoryGroup
                                select new Grouping<string, Product>(categoryGroup.Key, categoryGroup);

                    foreach (var item in items)
                        mProducts.Add(item);

                    clvProducts.ItemsSource = mProducts;
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

        private void ImageMenu_Clicked(object sender, EventArgs e)
        {
            try
            {
                Model.Common.MasterPage.IsGestureEnabled = false;
                Model.Common.MasterPage.IsPresented = true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void FrmProduct_Tapped(object sender, EventArgs e)
        {

            try
            {
                if (sender is Frame frmProduct && frmProduct.BindingContext is Product product)
                {
                    if (product != null)
                        Navigation.PushAsync(new ProductDetailsPage(product.id));
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async void SwipeItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (sender is SwipeItem swpdelete && swpdelete.BindingContext is Product product)
                {
                    ShowLoader(true);
                    var DeleteProductResult = await productAPI.DeleteProductByProductId(product.id);
                    if (DeleteProductResult != null)
                    {
                        ShowLoader(false);
                        Common.SuccessMessage("Record successfully deleted..");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowLoader(false);
                var msg = ex.Message;
            }
        }

        private void FrmNewProduct_Tapped(object sender, EventArgs e)
        {
            try
            {
                var addproductview = new AddProductView();
                addproductview.isLoaderevent += (s1, e1) =>
                {
                    bool isLoad = (bool)s1;
                    if (isLoad)
                        grdloader.IsVisible = isLoad;
                };
                addproductview.isRefresh += async (o, s) =>
                {
                    bool isSave = (bool)o;
                    if (isSave)
                    {
                        grdAddNewProduct.IsVisible = false;
                        grdmain.IsVisible = true;
                        Common.SuccessMessage("Success");
                        await BindAllProducts();
                    }
                    else
                    {
                        grdAddNewProduct.IsVisible = false;
                        grdmain.IsVisible = true;
                    }
                };
                grdAddNewProduct.Children.Add(addproductview);
                grdAddNewProduct.IsVisible = true;
                grdmain.IsVisible = false;
                //Navigation.PushAsync(new AddProductPage());
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }


            //AddProductPopupPage addProductPopupPage = new AddProductPopupPage("Hamja");
            //addProductPopupPage.isRefresh += (s1, e1) =>
            //{
            //    var name = (string)s1;
            //    if(!string.IsNullOrEmpty(name))
            //    {
            //        DisplayAlert(Title, name, "Ok");
            //    }
            //};
            //PopupNavigation.PushAsync(addProductPopupPage);
        }

    }
}