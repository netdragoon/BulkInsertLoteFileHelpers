using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Models.Abstract
{
    public class OrderList
    {
        public static NHibernate.Criterion.Order[] Create(params OrderItem[] orders)
        {
            if (orders == null) throw new Exception("No item in list");

            IList<NHibernate.Criterion.Order> items = 
                new List<NHibernate.Criterion.Order>(orders.Length);
            foreach (OrderItem order in orders)
            {
                items.Add(order.OrderType == OrderType.Asc
                    ? NHibernate.Criterion.Order.Asc(order.Name)
                    : NHibernate.Criterion.Order.Desc(order.Name));
            }
            return items.ToArray();
        }
    }
}
