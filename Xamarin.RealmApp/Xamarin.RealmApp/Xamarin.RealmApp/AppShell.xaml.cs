using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.RealmApp.ViewModels;
using Xamarin.RealmApp.Views;

namespace Xamarin.RealmApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
