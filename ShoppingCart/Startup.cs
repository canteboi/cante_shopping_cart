using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ShoppingCart.Security;

[assembly: OwinStartup(typeof(ShoppingCart.Startup))]

namespace ShoppingCart
{
    public partial class Startup
    {
        public static string TokenEndPoint = ConfigurationManager.AppSettings["Customer.TokenEndpoint"];
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            ConfigureOAuthTokenGeneration(app);
        }

        void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString(TokenEndPoint), 
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1), 
                //Provider = TelstraUserService.AuthorizationProvider,
                Provider = CustomerSecurityService.AuthorizationProvider,
                AccessTokenFormat = TokenService.Provider
            });
        }
    }
}
