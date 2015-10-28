using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ShoppingCart.Startup))]

namespace ShoppingCart
{
    public partial class Startup
    {
        public static string tokenEndPoint = ConfigurationManager.AppSettings["Customer.TokenEndpoint"];
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
