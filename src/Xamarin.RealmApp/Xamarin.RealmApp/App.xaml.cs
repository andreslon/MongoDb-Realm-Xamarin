using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;
using Prism.DryIoc;
using Prism.Events;
using Prism.Ioc;
using Xamarin.RealmApp.ViewModels;
using Xamarin.RealmApp.Views;
using Xamarin.RealmApp.Repositories;
using Xamarin.RealmApp.Interfaces;

namespace Xamarin.RealmApp
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.Register<IRouteRepository, RouteRepository>();
        }
    }
}
