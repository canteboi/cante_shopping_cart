using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Thinktecture.IdentityModel.Tokens;

namespace ShoppingCart.Security
{
    internal class TokenProvider : ISecureDataFormat<AuthenticationTicket>
    {
        readonly string _audienceId = ConfigurationManager.AppSettings["Customer.AudienceId"];
        readonly string _symmetricKeyBase64 = ConfigurationManager.AppSettings["Customer.AudienceSecret"];

        readonly string _issuer;
        readonly byte[] _symmetricKey;
        readonly HmacSigningCredentials _signingKey;
        readonly JwtBearerAuthenticationOptions consumptionOptions;
        readonly JwtSecurityTokenHandler tokenHandler;

        public TokenProvider(string issuer)
        {
            _issuer = issuer;

            this._symmetricKey = TextEncodings.Base64Url.Decode(_symmetricKeyBase64);
            this._signingKey = new HmacSigningCredentials(_symmetricKey);
        }

        public string Protect(AuthenticationTicket data)
        {
            var rawtoken = new JwtSecurityToken(
                _issuer,
                _audienceId,
                data.Identity.Claims,
                data.Properties.IssuedUtc.Value.UtcDateTime,
                data.Properties.ExpiresUtc.Value.UtcDateTime,
                _signingKey
                );

            return tokenHandler.WriteToken(rawtoken);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            var jwt = tokenHandler.ReadToken(protectedText) as JwtSecurityToken;
            var identity = new CustomerIdentity(jwt.Payload.Claims);

            return new AuthenticationTicket(identity, null);
        }
    }
}
