using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Xamarin.RealmApp.Interfaces;
using Xamarin.RealmApp.Models;

namespace Xamarin.RealmApp.Services
{
    internal class DatabaseService<T> : IDatabaseService<T> where T : RealmObject, new()
    {
        private Realm realm;

        public DatabaseService()
        {
            realm = Realm.GetInstance();
        }


        public IQueryable<T> GetAll()
        {
            return realm.All<T>().AsQueryable();
        }
        public T GetFirst(Expression<Func<T, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }
        public void Add(T entity)
        {
            realm.Write(() => realm.Add(entity));
        }
        public void AddRange(List<T> entities)
        {
            realm.Write(() =>
            {
                entities.Select(x => realm.Add(x)).ToList();
            });
        }
        public void Update(T entity)
        {
            realm.Write(() => realm.Add(entity, true));
        }
        public void UpdateRange(List<T> entities)
        {
            realm.Write(() =>
            {
                entities.Select(x => realm.Add(x, true)).ToList();
            });
        }

        public void Delete(T entity)
        {
            realm.Write(() =>
            {
                realm.Remove(entity);
            });
        }

        public void DeleteRange(List<T> entities)
        {
            realm.Write(() =>
            {
                realm.RemoveRange(entities.AsQueryable());
            });
        }


        private void StartObserver()
        {
            // Watch for Guitar collection changes.
            var token = realm.All<Route>()
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
