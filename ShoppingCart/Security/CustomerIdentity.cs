﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Security
{
    public class CustomerIdentity : ClaimsIdentity
    {
        internal CustomerIdentity(string authtype) : base(authtype) { }

        internal CustomerIdentity(IEnumerable<Claim> claims) : base(claims) { }
        public override bool IsAuthenticated
        {
            get
            {
                return this.FindFirst("emailaddress") != null;
            }
        }

        public override string Name
        {
            get
            {
                return this.FindFirst("emailaddress").Value;
            }
        }

        public string Password { get; set; }
    }
}
