using Plugin.FirebasePushNotification;
using Prism;
using Prism.Ioc;
using PushNotifyPrism.ViewModels;
using PushNotifyPrism.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace PushNotifyPrism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            var a = e.Token;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
