using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;

namespace ShoppingCart.Business
{
    interface IOrderService
    {
        List<Order> GetOrders();
        int AddOrder();
        void DeleteOrder();
        void UpdateOrder();
    }
}
