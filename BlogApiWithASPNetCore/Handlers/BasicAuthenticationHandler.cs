using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlogApiWithASPNetCore.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUnitOfWork _db;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUnitOfWork db)
            : base(options, logger, encoder, clock)
        {
            _db = db;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header not found");
            }
            else
            {
                try
                {
                    // decoding authToken we get decode value in 'Username:Password' format 
                    var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                    var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                    var decodedString = Encoding.UTF8.GetString(bytes);

                    // spliting decodeauthToken using ':'   
                    var splittedText = decodedString.Split(new char[] { ':' });

                    string username = splittedText[0];
                    string password = splittedText[1];

                    var userFromDb = _db.User.GetUserByUsernameNPassword(username, password);

                    if (userFromDb == null)
                    {
                        return AuthenticateResult.Fail("Invalid Credentials.");
                    }
                    else
                    {
                        var claims = new[] { new Claim(ClaimTypes.Name, userFromDb.Username) };
                        var identity = new ClaimsIdentity(claims, Scheme.Name);
                        var principal = new GenericPrincipal(identity, userFromDb.Role.Split(new char[] { ',' }));
                        var ticket = new AuthenticationTicket(principal, Scheme.Name);

                        return AuthenticateResult.Success(ticket);
                    }
                }
                catch (Exception)
                {

                    return AuthenticateResult.Fail("Unknown Error Has Occured.");
                }
            }
        }
    }
}
