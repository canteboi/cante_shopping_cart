using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Testing;

namespace ShoppingCart.Security
{
    internal static class TokenService
    {
        static TestServer tokenServer = TestServer.Create<Startup>();
        static TokenProvider tokenProvider;   

        internal static async Task<HttpResponseMessage> GenerateSecureToken()
        {

            var identity = CustomerSecurityService.GetUserFromContext();
            return await GenerateSecureToken(identity);
        }


        internal static async Task<HttpResponseMessage> GenerateSecureToken(string emailAdress)
        {

            var identity = CustomerSecurityService.GetUserFromEmailAddress(emailAdress);
            return await GenerateSecureToken(identity);
        }

        internal static async Task<HttpResponseMessage> GenerateSecureToken(CustomerIdentity identity)
        {
            var pairs = new List<KeyValuePair<string, string>>();

            pairs.Add(new KeyValuePair<string, string>("grant_type", "password"));
            pairs.Add(new KeyValuePair<string, string>("username", identity.Name));
            pairs.Add(new KeyValuePair<string, string>("password", ""));

            try
            {
                var tokenServiceResponse = await tokenServer.HttpClient.PostAsync(
                    Startup.TokenEndPoint,
                    new FormUrlEncodedContent(pairs)
                    );

                return tokenServiceResponse;
            }
            catch (Exception ex)
            {
                //Logger.LogException(ex, "Exception while creating JWT.");
                throw ex;
            }
        }

        internal static CustomerIdentity DecryptToken(string authorizationHeader)
        {
            throw new NotImplementedException();
        }

        internal static TokenProvider Provider
        {
            get
            {
                string issuer = ConfigurationManager.AppSettings["App.TokenIssuer"];
                return tokenProvider ?? (tokenProvider = new TokenProvider(issuer));
            }
        }
    }
}