using System;
using Api;
using Api.Infrastructure;
using BussinessAccess;
using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            ConfigAuth(appBuilder);
        }

        private static void ConfigAuth(IAppBuilder appBuilder)
        {
            appBuilder.UseOAuthAuthorizationServer(
                new OAuthAuthorizationServerOptions
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                    Provider = new AuthorizationServerProvider()
                    ,RefreshTokenProvider = new AuthenticationRefreshTokenProvider()
                });
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}