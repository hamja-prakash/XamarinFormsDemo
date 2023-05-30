using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNativeDemo.Model;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentView
    {
        #region [ Properties ]
        public List<Home> mHomes; 
        #endregion

        public HomeView()
        {
            InitializeComponent();
            
            mHomes = new List<Home>();
        }


        #region [ Methods ]
        public void BindHomeData()
        {
            try
            {
                mHomes.Add(new Home
                {
                    Image = "sample0.jpg",
                    Name = "Image1",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                });

                mHomes.Add(new Home
                {
                    Image = "sample1.jpg",
                    Name = "Image2",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                });

                mHomes.Add(new Home
                {
                    Image = "sample2.jpg",
                    Name = "Image2",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                });

                mHomes.Add(new Home
                {
                    Image = "sample3.jpg",
                    Name = "Image3",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                });

                mHomes.Add(new Home
                {
                    Image = "sample4.jpg",
                    Name = "Image4",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                });

                mHomes.Add(new Home
                {
                    Image = "sample5.jpg",
                    Name = "Image5",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                });

                mHomes.Add(new Home
                {
                    Image = "sample6.jpg",
                    Name = "Image6",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                });

                mHomes.Add(new Home
                {
                    Image = "sample7.jpg",
                    Name = "Image7",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                });

                clvHome.ItemsSource = mHomes.ToList();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        } 
        #endregion
    }
}