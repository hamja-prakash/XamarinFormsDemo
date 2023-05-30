using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomizeUIwithKeyboard : ContentPage
    {
        public CustomizeUIwithKeyboard()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        #region [ Events ]
        private void txtFirstName_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                //await ScrollViewContainer.ScrollToAsync(stkFirstName, ScrollToPosition.Start, true);
                Scroll(stkFirstName);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtLastName_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                //await ScrollViewContainer.ScrollToAsync(stkLastName, ScrollToPosition.Start, true);
                Scroll(stkLastName);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtEmail_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                //await ScrollViewContainer.ScrollToAsync(stkEmail, ScrollToPosition.Start, true);
                Scroll(stkEmail);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtPhoneNo_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                Scroll(stkPhoneNumber);
                //await ScrollViewContainer.ScrollToAsync(stkPhoneNumber, ScrollToPosition.Start, true);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtAddress_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                //await ScrollViewContainer.ScrollToAsync(stkAddress, ScrollToPosition.Start, true);
                Scroll(stkAddress);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtPassword_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                //await ScrollViewContainer.ScrollToAsync(stkPassword, ScrollToPosition.Start, true);
                Scroll(stkPassword);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtTest_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                //await ScrollViewContainer.ScrollToAsync(stkTest, ScrollToPosition.Start, true);
                Scroll(stkTest);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtTest1_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                //await ScrollViewContainer.ScrollToAsync(stkTest1, ScrollToPosition.Start, true);
                Scroll(stkTest1);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtTest2_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                Scroll(stkTest2);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtTest3_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                Scroll(stkTest3);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtTest4_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                Scroll(stkTest4);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }

        private void txtTest5_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                Scroll(stkTest5);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }

        }
        #endregion

        #region Methods
        public async void Scroll(Element value)
        {
            try
            {
                //double scrollPosition = entry.Y + entry.Height + 16; // Add some padding
                //await scrollView.ScrollToAsync(0, scrollPosition, true);
                await ScrollViewContainer.ScrollToAsync(value, ScrollToPosition.Start, true);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
        }
        #endregion

    }
}