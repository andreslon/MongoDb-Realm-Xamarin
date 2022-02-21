﻿using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Xamarin.RealmApp.Interfaces;
using Xamarin.RealmApp.Models;

namespace Xamarin.RealmApp.Services
{
    public class DatabaseService<T> : IDatabaseService<T> where T : RealmObject, new()
    {
        public Realm RealmInstance { get; set; }
        public DatabaseService()
        {
            RealmInstance = Realm.GetInstance();
        }
        public IQueryable<T> GetAll() { return RealmInstance.All<T>().AsQueryable(); }
        public T GetFirst(Expression<Func<T, bool>> predicate) { return GetAll().FirstOrDefault(predicate); }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) { return GetAll().Where(predicate); }
        public void Add(T entity) { RealmInstance.Write(() => RealmInstance.Add(entity)); }
        public void AddRange(List<T> entities)
        {
            RealmInstance.Write(() => { entities.Select(x => RealmInstance.Add(x)).ToList(); });
        }
        public void Update(T entity) { RealmInstance.Write(() => RealmInstance.Add(entity, true)); }
        public void UpdateRange(List<T> entities)
        {
            RealmInstance.Write(() => { entities.Select(x => RealmInstance.Add(x, true)).ToList(); });
        }
        public void Delete(T entity)
        {
            RealmInstance.Write(() => { RealmInstance.Remove(entity); });
        }
        public void DeleteRange(List<T> entities)
        {
            RealmInstance.Write(() => { RealmInstance.RemoveRange(entities.AsQueryable()); });
        }
        private void StartObserver()
        {
            // Watch for Guitar collection changes.
            var token = RealmInstance.All<Route>()
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
