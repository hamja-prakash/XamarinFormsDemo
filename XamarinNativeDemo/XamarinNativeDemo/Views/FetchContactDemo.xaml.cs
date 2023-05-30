using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNativeDemo.DependencyServices;
using XamarinNativeDemo.ViewModels;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    [DesignTimeVisible(false)]
    public partial class FetchContactDemo : ContentPage
    {
        public FetchContactDemo(IContactsService contactService)
        {
            InitializeComponent();
            this.BindingContext = new FetchContactViewModel(contactService);
        }
    }
}