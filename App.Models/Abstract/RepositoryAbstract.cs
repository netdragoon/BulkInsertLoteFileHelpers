using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using App.Models.Interfaces;
using NHibernate.Criterion;

namespace App.Models.Abstract
{
    public abstract class RepositoryAbstract<T> : IRepository<T>
        where T : ActiveRecordBase<T>
    {
        public T Insert(T model)
        {
            model.CreateAndFlush();
            return model;
        }

        public bool Update(T model)
        {
            try
            {
                model.UpdateAndFlush();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(T model)
        {
            try
            {
                model.DeleteAndFlush();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public T Find(object id)
        {
            return ActiveRecordBase<T>.TryFind(id);
        }

        public IEnumerable<T> All()
        {
            return ActiveRecordBase<T>.FindAll();
        }

        public IEnumerable<T> All(Order order)
        {
            return ActiveRecordBase<T>.FindAll(order);
        }
        public IEnumerable<T> All(Order[] order)
        {
            return ActiveRecordBase<T>.FindAll(order);
        }
    }
}
