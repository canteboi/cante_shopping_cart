using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentMethodId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentFirstname { get; set; }
        public string PaymentLastname { get; set; }
        public string PaymentAddress1 { get; set; }
        public string PaymentAddress2 { get; set; }
        public string PaymentCity { get; set; }
        public string PaymentPostcode { get; set; }
        public string PaymentCountry { get; set; }
        public string ShippingFirstname { get; set; }
        public string ShippingLastname { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostcode { get; set; }
        public string ShippingCountry { get; set; }
        public string Comment { get; set; }
        public decimal? Total { get; set; }
        public System.DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
