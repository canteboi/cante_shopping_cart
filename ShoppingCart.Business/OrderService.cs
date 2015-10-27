using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;
using CartItem = ShoppingCart.Model.CartItem;
using DbOrder = ShoppingCart.Data.Order;
using Order = ShoppingCart.Model.Order;

namespace ShoppingCart.Business
{
    public class OrderService : IOrderService
    {
        private readonly ShoppingCartDbEntities _dbEntities;

        public OrderService()
        {
            _dbEntities = new ShoppingCartDbEntities();
        }
        public List<Order> GetOrders(int customerId)
        {
            var dbOrders = _dbEntities.Orders.Where(x => x.customer_id == customerId);
            var orders = dbOrders.ToList().ConvertAll(x => new Order()
            {
                OrderId             = x.order_id,
                CustomerId          = x.customer_id,
                OrderStatusId       = x.order_status_id,
                PaymentMethodId     = x.payment_method_id,
                PaymentMethod       = x.payment_method,
                PaymentFirstname    = x.payment_firstname,
                PaymentLastname     = x.payment_lastname,
                PaymentAddress1     = x.payment_address_1,
                PaymentAddress2     = x.payment_address_2,
                PaymentCity         = x.payment_city,
                PaymentPostcode     = x.payment_postcode,
                PaymentCountry      = x.payment_country,
                ShippingFirstname   = x.shipping_firstname,
                ShippingLastname    = x.shipping_lastname,
                ShippingAddress1    = x.shipping_address_1,
                ShippingAddress2    = x.shipping_address_2,
                ShippingCity        = x.shipping_city,
                ShippingPostcode    = x.shipping_postcode,
                ShippingCountry     = x.shipping_country,
                Comment             = x.comment,
                Total               = x.total,
                DateAdded           = x.date_added,
                DateModified        = x.date_modified
            });

            return orders;
        }

        public Order GetOrder(int customerId)
        {
            try
            {
                var recentOrder = _dbEntities.Orders.OrderByDescending(x => x.date_modified)
                                                        .SingleOrDefault(x => x.customer_id == customerId);

                if (recentOrder != null)
                {
                    return new Order
                    {
                        OrderId = recentOrder.order_id,
                        CustomerId = recentOrder.customer_id,
                        OrderStatusId = recentOrder.order_status_id,
                        PaymentMethodId = recentOrder.payment_method_id,
                        PaymentMethod = recentOrder.payment_method,
                        PaymentFirstname = recentOrder.payment_firstname,
                        PaymentLastname = recentOrder.payment_lastname,
                        PaymentAddress1 = recentOrder.payment_address_1,
                        PaymentAddress2 = recentOrder.payment_address_2,
                        PaymentCity = recentOrder.payment_city,
                        PaymentPostcode = recentOrder.payment_postcode,
                        PaymentCountry = recentOrder.payment_country,
                        ShippingFirstname = recentOrder.shipping_firstname,
                        ShippingLastname = recentOrder.shipping_lastname,
                        ShippingAddress1 = recentOrder.shipping_address_1,
                        ShippingAddress2 = recentOrder.shipping_address_2,
                        ShippingCity = recentOrder.shipping_city,
                        ShippingPostcode = recentOrder.shipping_postcode,
                        ShippingCountry = recentOrder.shipping_country,
                        Comment = recentOrder.comment,
                        Total = recentOrder.total,
                        DateAdded = recentOrder.date_added,
                        DateModified = recentOrder.date_modified
                    };
                }

                return null;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public int AddOrder(Order order)
        {
            try
            {
                var dborder = new DbOrder()
                {
                    customer_id         = order.CustomerId       ,       
                    order_status_id     = order.OrderStatusId    ,    
                    payment_method_id   = order.PaymentMethodId  ,  
                    payment_method      = order.PaymentMethod    ,    
                    payment_firstname   = order.PaymentFirstname , 
                    payment_lastname    = order.PaymentLastname  ,  
                    payment_address_1   = order.PaymentAddress1  , 
                    payment_address_2   = order.PaymentAddress2  ,
                    payment_city        = order.PaymentCity      ,
                    payment_postcode    = order.PaymentPostcode  ,
                    payment_country     = order.PaymentCountry   ,
                    shipping_firstname  = order.ShippingFirstname,
                    shipping_lastname   = order.ShippingLastname ,
                    shipping_address_1  = order.ShippingAddress1 ,
                    shipping_address_2  = order.ShippingAddress2 ,
                    shipping_city       = order.ShippingCity     ,
                    shipping_postcode   = order.ShippingPostcode ,
                    shipping_country    = order.ShippingCountry  ,
                    comment             = order.Comment          ,
                    total               = order.Total            ,
                };

                dborder = _dbEntities.Orders.Add(dborder);
                _dbEntities.SaveChanges();

                return dborder.order_id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateOrder(Order order)
        {
            var dborder = _dbEntities.Orders.SingleOrDefault(x => x.order_id == order.OrderId);

            if (dborder == null)
            {
                throw new ObjectNotFoundException(string.Format(" Order Id of :{0} was not found", order.OrderId));
            }

            try
            {
                dborder.customer_id         = order.CustomerId       ;
                dborder.order_status_id     = order.OrderStatusId    ;
                dborder.payment_method_id   = order.PaymentMethodId  ;
                dborder.payment_method      = order.PaymentMethod    ;
                dborder.payment_firstname   = order.PaymentFirstname ;
                dborder.payment_lastname    = order.PaymentLastname  ;
                dborder.payment_address_1   = order.PaymentAddress1  ;
                dborder.payment_address_2   = order.PaymentAddress2  ;
                dborder.payment_city        = order.PaymentCity      ;
                dborder.payment_postcode    = order.PaymentPostcode  ;
                dborder.payment_country     = order.PaymentCountry   ;
                dborder.shipping_firstname  = order.ShippingFirstname;
                dborder.shipping_lastname   = order.ShippingLastname ;
                dborder.shipping_address_1  = order.ShippingAddress1 ;
                dborder.shipping_address_2  = order.ShippingAddress2 ;
                dborder.shipping_city       = order.ShippingCity     ;
                dborder.shipping_postcode   = order.ShippingPostcode ;
                dborder.shipping_country    = order.ShippingCountry  ;
                dborder.comment             = order.Comment          ;
                dborder.total               = order.Total;
                dborder.date_modified       = DateTime.Now;

                _dbEntities.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
