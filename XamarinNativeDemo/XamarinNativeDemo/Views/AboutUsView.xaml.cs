using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutUsView : ContentView
    {
        public List<string> images;

        public AboutUsView()
        {
            InitializeComponent();
            images = new List<string>();
            BindCarousalViewData();
        }

        public void BindCarousalViewData()
        {
            try
            {
                images.Add("sample_0.jpg");
                images.Add("sample_1.jpg");
                images.Add("sample_2.jpg");
                images.Add("sample_3.jpg");
                images.Add("sample_4.jpg");
                carslDogs.ItemsSource = images.ToList();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }
    }
}