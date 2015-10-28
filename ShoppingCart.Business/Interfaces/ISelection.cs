using System.Collections.Generic;
using ShoppingCart.Model;
using DbPaymentMethod = ShoppingCart.Data.Payment_Method;
using DbOrderStatus = ShoppingCart.Data.Order_Status;

namespace ShoppingCart.Business
{
    public interface ISelectionService
    {
        List<PaymentMethod> GetPaymentMethods();
        List<OrderStatus> GetOrderStatus();
    }
}
