using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCart.Business;

namespace ShoppingCart.Controllers
{
    public class SelectionApiController : ApiController
    {
        private readonly ISelectionService _selectionService;

        public SelectionApiController()
        {
            _selectionService = new SelectionServiceService();
        }

        [HttpGet]
        [Route("api/orderstatus")]
        public HttpResponseMessage GetOrderStatus()
        {

            var records = _selectionService.GetOrderStatus();

            return Request.CreateResponse(HttpStatusCode.OK, records);
        }

        [HttpGet]
        [Route("api/paymentmethods")]
        public HttpResponseMessage GetPaymentMethods()
        {

            var records = _selectionService.GetPaymentMethods();

            return Request.CreateResponse(HttpStatusCode.OK, records);
        }
    }
}
