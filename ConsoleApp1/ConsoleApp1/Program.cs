using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretKey = KeyIssuer.GenerateSharedSymmetricKey();
            SigningCredentials a = GetSigningCredentials();

            var key = new byte[64];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            string apiKey = Convert.ToBase64String(key);


            //// Initialization.  
            //string myPassword = "mypassword";
            //string mysaltKey = "mysaltkey";

            //// Generate API key.  
            //string apiKey = RESTWebAPIKey.GenerateAPIKey(myPassword, mysaltKey);





            //// Token issuer
            // TokenIssuer issuer = new TokenIssuer();
            //issuer.ShareKeyOutofBand("MyRelyingPartApp", secretKey);

            //// Relying Party
            // RelyingParty app = new RelyingParty();
            // app.ShareKeyOutofBand(secretKey);
            //// // A client of the relying party app gets the token
            // string token = issuer.GetToken("MyRelyingPartApp", "opensesame");

            //// With the token, the client now presents the token and
            ////  calls the method requiring authorization
            // app.Authenticate(token);
            // app.TheMethodRequiringAuthZ(); 
        }
        public static SigningCredentials GetSigningCredentials()
        {
            var symmetricKey = Convert.FromBase64String("zZmyy/bb7MxDt9Rk7fXx1UfLBSUEpNaPCtwm4N2QnIlzte7iv+Ikc3II/a8xsAG2IxIkPoQ5LWACqWbOPfexTBhGqfUJYzM/VHqKT0yk5td82X969u6DWYXzAQXtHNB7fckCyR4zqRQvxJuPlrpQo671I4GBl7hYUcSEUo9XgPQ=");

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(symmetricKey);

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            return credentials;
        }
        public class KeyIssuer
        {
            public static string GenerateSharedSymmetricKey()
            {

                // 256-bit key
                using (var provider = new RNGCryptoServiceProvider())
                {
                    byte[] secretKeyBytes = new Byte[128];
                    provider.GetBytes(secretKeyBytes);

                    return Convert.ToBase64String(secretKeyBytes);
                }
            }
        }
        //public class TokenIssuer
            //{
            //    private Dictionary<string, string> audienceKeys = new Dictionary<string, string>();

            //    // This method is called to register a key with the token issuer against an audience or an RP    public void ShareKeyOutofBand(string audience, string key)    {        if (!audienceKeys.ContainsKey(audience))            audienceKeys.Add(audience, key);        else            audienceKeys[audience] = key;    }

            //    public string GetToken(string audience, string credentials)
            //    {       
            //        // Ignoring the credentials and adding a few claims for illustration
            //        JsonWebToken token = new JsonWebToken()
            //        {
            //            SymmetricKey = audienceKeys[audience],
            //            Issuer = "TokenIssuer",
            //            Audience = audience
            //        };

            //        token.AddClaim(ClaimTypes.Name, "jqhuman"); token.AddClaim(ClaimTypes.Role, "Developer"); token.AddClaim(ClaimTypes.Role, "Admin");
            //        return token.ToString();
            //    }
            //}
            //public class RelyingParty
            //{
            //    private string secretKey = String.Empty;

            //    public void ShareKeyOutofBand(string key) { this.secretKey = key; }

            //    public void Authenticate(string token)
            //    {
            //        JsonWebToken jwt = null;

            //        try
            //        {
            //            jwt = JsonWebToken.Parse(token, this.secretKey);

            //            // Now, swt.Claims will have the list of claims
            //            jwt.Claims.ToList().ForEach(c => Console.WriteLine("{0} ==> {1}", c.Type, c.Value));

            //            Thread.CurrentPrincipal = new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, "JWT"));
            //        }
            //        catch (Exception ex) { Console.WriteLine(ex.Message); }
            //    }

            //    [PrincipalPermission(SecurityAction.Demand, Role = "Developer")]
            //    public void TheMethodRequiringAuthZ()
            //    { Console.WriteLine("With great power comes great responsibility - Uncle Ben"); }
            //}

    }
}
