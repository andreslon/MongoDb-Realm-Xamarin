using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.RealmApp.Models;

namespace Xamarin.RealmApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Route> Routes { get; set; } = new ObservableCollection<Route>();
        public Route NewRoute { get; set; }
        public ICommand SaveRouteCommand => new DelegateCommand(SaveRoute);
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main";
            CreateRoute();
        }
        private void CreateRoute()
        {
            if (NewRoute!=null)
                NewRoute.Name = String.Empty;
            NewRoute = new Route();
        }
        private void SaveRoute()
        {
            Routes.Add(NewRoute);
            CreateRoute();
        }
    }
}
