using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Model;
using ShoppingCart.Business;

namespace ShoppingCart.Controllers
{
    public class AdminProductsApiController : ApiController
    {
        private readonly IProductService _productService;

        public AdminProductsApiController()
        {
            _productService = new ProductService();
        }

        [HttpGet]
        [Route("api/admin/products")]
        public HttpResponseMessage GetProducts()
        {
            var products = _productService.GetProducts();

            return Request.CreateResponse(HttpStatusCode.OK, products);
        }


        [HttpPost]
        [Route("api/admin/products/{productId}")]
        public HttpResponseMessage UpdateProduct([FromBody] Product product)
        {
            _productService.UpdateProduct(product);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/admin/products/{productId}")]
        public HttpResponseMessage DeleteProduct(int productid)
        {
            _productService.DeleteProduct(productid);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
