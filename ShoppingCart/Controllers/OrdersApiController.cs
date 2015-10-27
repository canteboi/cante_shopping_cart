using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Model;
using ShoppingCart.Business;

namespace ShoppingCart.Controllers
{
    public class OrdersApiController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrdersApiController()
        {
            _orderService = new OrderService();
        }

        [HttpGet]
        [Route("api/orders/{customerId}")]
        public HttpResponseMessage Get(int customerId)
        {

            var orders = _orderService.GetOrders(customerId);

            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }

        [HttpPost]
        [Route("api/orders/{customerId}")]
        public HttpResponseMessage Post([FromBody] Order order)
        {
            _orderService.UpdateOrder(order);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
