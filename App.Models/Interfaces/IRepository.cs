using System.Collections.Generic;
using Castle.ActiveRecord;

namespace App.Models.Interfaces
{
    public interface IRepository<T>
        where T : ActiveRecordBase<T>
    {
        T Insert(T model);
        bool Update(T model);
        bool Delete(T model);
        T Find(object id);
        IEnumerable<T> All();
        IEnumerable<T> All(NHibernate.Criterion.Order order);
        IEnumerable<T> All(NHibernate.Criterion.Order[] order);
    }
}
