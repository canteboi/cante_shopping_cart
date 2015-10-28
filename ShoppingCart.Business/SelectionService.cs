using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Data;
using ShoppingCart.Model;

namespace ShoppingCart.Business
{
    public class SelectionServiceService : ISelectionService
    {
        private readonly ShoppingCartDbEntities _dbEntities;

        public SelectionServiceService()
        {
            _dbEntities = new ShoppingCartDbEntities();
        }

        public List<PaymentMethod> GetPaymentMethods()
        {
            var paymentmethods = _dbEntities.Payment_Method.ToList()
                .ConvertAll(x => new PaymentMethod()
                {
                    Name = x.name,
                    PaymentMethodId = x.payment_method_id
                });

            return paymentmethods;
        }

        public List<OrderStatus> GetOrderStatus()
        {
            var orderstatus = _dbEntities.Order_Status.ToList()
                .ConvertAll(x => new OrderStatus()
                {
                    Name = x.name,
                    OrderStatusId = x.order_status_id
                });

            return orderstatus;
        }
    }
}
