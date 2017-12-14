using System;
using System.Linq;
using System.Threading.Tasks;
using BussinessAccess;
using DataModel;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;

namespace Api.Infrastructure
{
    public class AuthenticationRefreshTokenProvider : IAuthenticationTokenProvider
    {
        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientId = context.Ticket.Properties.Dictionary["as:client_id"];
            var tokenId = Guid.NewGuid();

            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(10),
                IssuedUtc = context.Ticket.Properties.IssuedUtc
            };

            var token = new RefreshTokenModel()
            {
                RefreshTokenId = tokenId,
                ClientId = clientId,
                UserId = new Guid(context.Ticket.Identity.Claims.Single(c => c.Type == "UserId").Value),
                IssuedUtc = refreshTokenProperties.IssuedUtc.Value.DateTime,
                ExpiresUtc = refreshTokenProperties.ExpiresUtc.Value.DateTime,
                ProtectedTicket = context.SerializeTicket()
            };

            await new UserLoginManager().CreateRefreshTokenAsync(token);
            context.SetToken(tokenId.ToString());
            await Task.FromResult<object>(null);
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var allowOrigin = context.OwinContext.Get<string>("as:clientAllowOrigin") ?? "*";
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {allowOrigin});
            var isValidToken = await new UserLoginManager().CheckIfheIncomingTokenIsPresent(Guid.Parse(context.Token));
            if (!isValidToken)
            {
                var response = context.Response;
                response.OnSendingHeaders(state =>
                {
                    var owinResponse = (OwinResponse) state;
                    owinResponse.StatusCode = 401;
                    owinResponse.ReasonPhrase = "Unauthorized Login";
                }, response);
            }

            var refreshToken = await new UserLoginManager().DeleteRefreshTokenAsync(Guid.Parse(context.Token));
            if (refreshToken != null)
            {
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                context.SetTicket(context.Ticket);
            }

            await Task.FromResult<object>(null);
        }
    }
}