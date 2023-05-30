using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
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
    public partial class AddProductView : ContentView
    {
        public EventHandler isRefresh;
        public EventHandler isLoaderevent;
        public ProductAPI productAPI;
        public string productImg;
        public byte[] imgByteArray;

        public AddProductView()
        {
            InitializeComponent();
            BindCategoryData();
            productAPI = new ProductAPI();
        }

        public void BindCategoryData()
        {
            try
            {
                List<string> mCategories = new List<string>();
                mCategories.Add("Electronics");
                mCategories.Add("Jewelery");
                mCategories.Add("Men's Clothing");
                mCategories.Add("Women's Clothing");
                pckCategory.ItemsSource = mCategories.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidateControl()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                isValid = false;
                Common.AlertMessage("please enter title");
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                isValid = false;
                Common.AlertMessage("please enter price");
            }
            else if (pckCategory.SelectedIndex == -1)
            {
                isValid = false;
                Common.AlertMessage("please select category");
            }
            else if (string.IsNullOrEmpty(txtDescription.Text))
            {
                isValid = false;
                Common.AlertMessage("please enter description");
            }
            else
                isValid = true;
            return isValid;
        }

        public async Task UpsertProduct()
        {
            var productRequest = new ProductRequest();
            Common.ProductId += 1;
            productRequest.id = Common.ProductId;
            productRequest.title = txtTitle.Text;
            productRequest.price = txtPrice.Text;
            productRequest.category = pckCategory.SelectedItem.ToString();
            productRequest.description = txtDescription.Text;
            //var prdimg = PhotoImage.Source.ToString().Replace("file: ", "");
            //productRequest.image = productImg;
            ShowLoader(true);
            var productResult = await productAPI.InsertProduct(productRequest);
            if (productResult != null)
            {
                ShowLoader(false);
                isRefresh.Invoke(true, new EventArgs());
                //Common.SuccessMessage("Product has been successfully added..");
            }
        }

        public void ShowLoader(bool isLoad)
        {
            try
            {
                if (isLoaderevent != null)
                {
                    isLoaderevent.Invoke(isLoad, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async void ImageEdit_Clicked(object sender, EventArgs e)
        {
            string action = await App.Current.MainPage.DisplayActionSheet("Action", "Cancel", "", "Pick Photo", "Take Photo");
            if (action == "Take Photo")
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Test",
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Front
                });

                if (file == null)
                    return;

                var image = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    //imgByteArray = ConvertStreamToByteArray(stream);
                    return stream;
                });
                PhotoImage.Source = image;
            }
            else if (action == "Pick Photo")
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    App.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                });

                if (file == null)
                    return;

                var image = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    //imgByteArray = ConvertStreamToByteArray(stream);
                    return stream;
                });
                PhotoImage.Source = image;

                //using (MemoryStream memory = new MemoryStream())
                //{
                //    Stream stream = file.GetStream();
                //    stream.CopyTo(memory);
                //    imageArray = memory.ToArray();
                //}
            }
        }

        private async void frmSave_Tapped(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControl())
                    await UpsertProduct();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void imgBackBtn_Clicked(object sender, EventArgs e)
        {
            isRefresh.Invoke(false, EventArgs.Empty);
        }

        private void pckCategory_Clicked(object sender, EventArgs e)
        {
            try
            {
                pckCategory.Focus();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}