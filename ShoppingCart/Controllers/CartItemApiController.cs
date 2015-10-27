using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Business;
using ShoppingCart.Model;

namespace ShoppingCart.Controllers
{
    public class CartItemApiController : ApiController
    {
        private readonly ICartItemService _cartItemService;

        public CartItemApiController()
        {
            _cartItemService = new CartItemService();
        }


        [HttpGet]
        [Route("api/cartitems/{customerId}")]
        public HttpResponseMessage Get(int customerId)
        {
            var items = _cartItemService.GetCartItems(customerId);

            return Request.CreateResponse(HttpStatusCode.OK, items);
        }

        [HttpPost]
        [Route("api/cartitems/{customerId}")]
        public HttpResponseMessage Post([FromBody] CartItem cartItem)
        {
            _cartItemService.UpdateCartItem(cartItem);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/cartitems/{customerId}")]
        public HttpResponseMessage Delete(int customerId)
        {
            _cartItemService.DeleteCartItem(customerId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
