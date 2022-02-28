using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.RealmApp.Interfaces;
using Xamarin.RealmApp.Models;

namespace Xamarin.RealmApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Route> Routes { get; set; } = new ObservableCollection<Route>();

        private Route _route;
        public Route NewRoute
        {
            get { return _route; }
            set
            {
                SetProperty(ref _route, value);
                _route = value;
            }
        }

        public ICommand SaveOrUpdateRouteCommand => new DelegateCommand(SaveOrUpdateRoute);
        public ICommand ClearRouteCommand => new DelegateCommand(ClearRoute);
        public IRouteRepository RouteRepository { get; set; }
        public ICommand EditRouteCommand => new DelegateCommand<Route>(EditRoute);
        public MainPageViewModel(INavigationService navigationService, IRouteRepository routeRepository)
            : base(navigationService)
        {
            Title = "Main";
            RouteRepository = routeRepository;
            LoadRoutes();
            NewRoute = new Route();
        }
        private void ClearRoute()
        {
            NewRoute = new Route();
        }
        private void SaveOrUpdateRoute()
        {
            RouteRepository.AddOrUpdate(NewRoute);
            LoadRoutes();
            ClearRoute();
        }
        private void EditRoute(Route route)
        {
            NewRoute = route;
        }
        private void LoadRoutes()
        {
            var routesList = RouteRepository.GetAll();
            Routes.Clear();
            foreach (var item in routesList)
                Routes.Add(item);
        }
    }
}
