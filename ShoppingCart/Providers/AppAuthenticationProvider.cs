using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using ShoppingCart.Business;
using ShoppingCart.Security;

namespace ShoppingCart.Providers
{
    public class AppAuthenticationProvider : OAuthAuthorizationServerProvider
    {

        readonly ICustomerService _customerService;

        public AppAuthenticationProvider () {
            this._customerService = new CustomerService();
        }

        public AppAuthenticationProvider(ICustomerService dao)
        {
            this._customerService = dao;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //if (context.ClientId == _publicClientId)
            //{
            //    Uri expectedRootUri = new Uri(context.Request.Uri, "/");

            //    if (expectedRootUri.AbsoluteUri == context.RedirectUri)
            //    {
            //        context.Validated();
            //    }
            //    else if (context.ClientId == "web")
            //    {
            //        var expectedUri = new Uri(context.Request.Uri, "/");
            //        context.Validated(expectedUri.AbsoluteUri);
            //    }
            //}
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            const string emailaddress = "emailaddress";

            var identity = new CustomerIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim(emailaddress, context.UserName));


            context.Validated(new AuthenticationTicket(identity, null));
        }
    }
}
