using Plugin.AppShortcuts;
using Plugin.AppShortcuts.Icons;
using System;
using System.Linq;
using Xamarin.Forms;
using XamarinNativeDemo.DependencyServices;
using XamarinNativeDemo.Helper;
using XamarinNativeDemo.Views;
using XamarinNativeDemo.Views.MaterPage;
using XamarinNativeDemo.Views.Menu;

namespace XamarinNativeDemo
{
    public partial class App : Application
    {
        public const string AppShortcutUriBase = "asfs://XamarinNativeDemo/";
        public const string ShortcutOption1 = "ProductPage";
        //IContactsService _contactsService;

        public App(/*IContactsService contactsService*/)
        {
            //_contactsService = contactsService;

            AddShortcuts();

            InitializeComponent();

            Model.Common.MasterPage = new MasterPage();
            Model.Common.MasterPage.Master = new MenuPage() { Title = "Menu Page" };
            Model.Common.MasterPage.Detail = new NavigationPage(new HomePage("Home"));

            MainPage = new NavigationPage(new PermissionPage());
            //MainPage = new NavigationPage(new SinglePermissionPage());
            //MainPage = new NavigationPage(new PermissionUngrantedPage());

            //MainPage = new NavigationPage(Model.Common.MasterPage); //Main Project flow start here

            //MainPage = new NavigationPage(new FetchContactDemo(_contactsService));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        async void AddShortcuts()
        {
            if (CrossAppShortcuts.IsSupported)
            {

                var shortCurts = await CrossAppShortcuts.Current.GetShortcuts();
                if (shortCurts.FirstOrDefault(prop => prop.Label == "Detail") == null)
                {
                    var shortcut = new Shortcut()
                    {
                        Label = "Detail",
                        Description = "Product",
                        Icon = new ContactIcon(),
                        Uri = $"{AppShortcutUriBase}{ShortcutOption1}"
                    };
                    await CrossAppShortcuts.Current.AddShortcut(shortcut);
                }
            }

        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            var option = uri.ToString().Replace(AppShortcutUriBase, "");
            if (!string.IsNullOrEmpty(option))
            {
                MainPage = new NavigationPage(new MainPage());
                MainPage.Navigation.PushAsync(new ProductPage());
            }
            else
                base.OnAppLinkRequestReceived(uri);
        }
    }
}
