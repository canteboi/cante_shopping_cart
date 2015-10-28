using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using ShoppingCart.Business;
using ShoppingCart.Model;
using ShoppingCart.Security;
using CustomerService = ShoppingCart.Business.CustomerService;

namespace ShoppingCart.Controllers
{
    public class SecurityApiController : ApiController
    {
        private readonly ICustomerService _customerService;

        public SecurityApiController()
        {
            _customerService = new CustomerService();
        }

        [HttpPost]
        [Route("api/security/customer/validate")]
        public async Task<IHttpActionResult> GenerateSecureTokenForCurrentLoggedInUser([FromBody] dynamic obj)
        {
            string emailAddress = obj.emailAddress;
            string password = obj.password;            

            var customer = _customerService.GetCustomer(emailAddress);
            var dbpassword = Cryptography.Decrypt(customer.Password, emailAddress, customer.Salt, null);

            if (string.Equals(dbpassword, password, StringComparison.InvariantCultureIgnoreCase))
            {
                return this.ResponseMessage(await TokenService.GenerateSecureToken());    
            }

            return this.BadRequest("Invalid Email Address or Password");
        }

        [HttpPost]
        [Route("api/security/customer/add")]
        public async Task<IHttpActionResult> Add([FromBody] dynamic obj)
        {
            //var user = HttpContext.Current.User.Identity;
            string emailAddress = obj.emailAddress;
            string password = obj.password;
            var salt = Cryptography.GenerateSalt();

            password = Cryptography.Encrypt(password, emailAddress, salt, string.Empty);

            var customer = new Customer
            {
                Firstname = "Test",
                Lastname = "LastName",
                Email = emailAddress,
                Password = password,
                Salt = salt,
                Status = "Active",
                Telephone = "231325",
                Token = "324543534543"
            };

            _customerService.AddCustomer(customer);

            return this.Ok();
        }
    }
}
