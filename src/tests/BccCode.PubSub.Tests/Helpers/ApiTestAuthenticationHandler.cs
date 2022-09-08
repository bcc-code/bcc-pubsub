using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BccCode.PubSub.Tests.Fakes
{
    public class ApiTestAuthenticationOptions : AuthenticationSchemeOptions
    {

    }
    public  class ApiTestAuthenticationHandler : AuthenticationHandler<ApiTestAuthenticationOptions>
    {
        public ApiTestAuthenticationHandler(
        IOptionsMonitor<ApiTestAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock) : base(options, logger, encoder, clock)
        {

        }

        public const string AuthenticationScheme = "Test";

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "API") };

            
            if (Context.Request.Headers.TryGetValue("X-TEST-AUTH-SCOPE", out var scopes))
            {
                foreach (var scope in scopes)
                {
                    claims.Add(new Claim("scope", scope));
                }                
            }

            var identity = new ClaimsIdentity(claims, AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, AuthenticationScheme);

            var result = AuthenticateResult.Success(ticket);

            return Task.FromResult(result);
        }
    }
}
