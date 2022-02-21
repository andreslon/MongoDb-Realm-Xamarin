using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.RealmApp.Interfaces;
using Xamarin.RealmApp.Models;
using Xamarin.RealmApp.Services;

namespace Xamarin.RealmApp.Repositories
{ 
    public class RouteRepository : DatabaseService<Route>, IRouteRepository
    {
        public RouteRepository()
        {

        }
    }
}
