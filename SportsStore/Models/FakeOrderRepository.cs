using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{

    public class FakeOrderRepository : IOrderRepository
    {
        List<Order> orders;

        public IQueryable<Order> Orders
        {
            get
            {
                if (orders == null)
                    orders = new List<Order>();
                return orders.AsQueryable<Order>();
            }
        }

        public void SaveOrder(Order order)
        {
            orders?.Add(order);
        }
    }
}
