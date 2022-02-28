using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Xamarin.RealmApp.Interfaces
{
    public interface IDatabaseService<T>
    {
        IQueryable<T> GetAll();
        T GetFirst(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void AddOrUpdate(T entity);
        void AddOrUpdateRange(List<T> entities); 
        void Delete(T entity);
        void DeleteRange(List<T> entities);
    }
}
