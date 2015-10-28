using System.Collections.Generic;
using ShoppingCart.Model;
using DbOrder = ShoppingCart.Data.Order;

namespace ShoppingCart.Business
{
    public interface IOrderService
    {
        List<Order> GetOrders(int customerId);
        Order GetOrder(int customerId);
        int AddOrder(Order order);
        void UpdateOrder(Order order);
    }
}
