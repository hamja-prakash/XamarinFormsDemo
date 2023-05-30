using Plugin.PayCards;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanCardDemo : ContentPage
    {
        public PayCard Card;
        public ScanCardDemo()
        {
            InitializeComponent();
        }

        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            Card = await CrossPayCards.Current.ScanAsync().ConfigureAwait(true);
            if(Card != null)
            {
                lblHolderName.Text = Card.HolderName;
                lblCardNumber.Text = Card.CardNumber;
                lblExpirationDate.Text = Card.ExpirationDate;
            }
        }
    }
}