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
    public class ProductsApiController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsApiController()
        {
            _productService = new ProductService();
        }

        [HttpGet]
        [Route("api/products")]
        public HttpResponseMessage GetProducts()
        {
            var products = _productService.GetProducts();

            return Request.CreateResponse(HttpStatusCode.OK, products);
        }


    }
}
