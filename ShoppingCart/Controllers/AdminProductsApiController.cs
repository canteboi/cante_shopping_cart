using System;
using System.Collections.Generic;
using System.Web.Http;
using ShoppingCart.Model;

namespace ShoppingCart.Controllers
{
    public class AdminProductsApiController : ApiController
    {

        [HttpGet]
        [Route("api/admin/products")]
        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }


    }
}
