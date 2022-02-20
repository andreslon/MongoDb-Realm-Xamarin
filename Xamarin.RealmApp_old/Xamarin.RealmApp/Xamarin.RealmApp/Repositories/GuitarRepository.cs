using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.RealmApp.Models;

namespace Xamarin.RealmApp.Repositories
{
    public class GuitarRepository
    {
        private Realm realm;

        public GuitarRepository()
        {
            realm = Realm.GetInstance();
            StartObserver();
        }

        private void Add()
        {
            realm.Write(() =>
            {
                realm.Add(new Guitar()
                {
                    Make = "Gibson",
                    Model = "Les Paul Custom",
                    Price = 649.99,
                    Owner = "N. Young"
                });
            });
        }

        private void Get()
        {
            var allGuitars = realm.All<Guitar>();

        }

        private void Update()
        {
            var harrysStrat = realm.All<Guitar>().FirstOrDefault(
                                      g => g.Owner == "D. Gilmour"
                                      && g.Make == "Fender"
                                      && g.Model == "Stratocaster");
            realm.Write(() =>
            {
                harrysStrat.Price = 322.56;
            });
        }

        private void Delete()
        {
            var mostExpensiveGuitar = realm.All<Guitar>()
                .OrderByDescending(g => g.Price).First();
            realm.Write(() =>
            {
                realm.Remove(mostExpensiveGuitar);
            });
        }



        private void StartObserver()
        {
            // Watch for Guitar collection changes.
            var token = realm.All<Guitar>()
                .SubscribeForNotifications((sender, changes, error) =>
                {
                    foreach (var i in changes.DeletedIndices)
                    {
                        // ... handle deletions ...
                    }
                    foreach (var i in changes.InsertedIndices)
                    {
                        // ... handle insertions ...
                    }
                    foreach (var i in changes.NewModifiedIndices)
                    {
                        // ... handle modifications ...
                    }
                });
        }
    }
}
