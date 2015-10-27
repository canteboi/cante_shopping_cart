using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingCart.Security
{
    internal static class CustomerService
    {
        internal static CustomerIdentity GetCustomerIdentity(string emailaddress)
        {
            var identity = new CustomerIdentity("Claims");
            identity.AddClaim(new Claim("emailaddress", emailaddress));

            return identity;
        }

        internal static CustomerIdentity GetCurrentUser()
        {
            var authorizationHeader = HttpContext.Current.Request.Headers["X-Jenni-Authorization"] ?? "";

            // ::   if the bearer token is still the same as the original 
            //      Authorization header, then this is not a Bearer token.
            if (string.IsNullOrWhiteSpace(authorizationHeader))
            {
                return GetUserFromContext();
            }
            else
            {
                return TokenService.DecryptToken(authorizationHeader);
            }
        }

        internal static CustomerIdentity GetUserFromContext()
        {
            var user = HttpContext.Current.User.Identity;
            var emailAddress = user.Name;


            return GetCustomerIdentity(emailAddress);
        }
    }
}
