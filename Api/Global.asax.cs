using System;
using System.Web;
using System.Web.Http;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //AutoMapperConfig.Register();
            DependancyResolverConfig.Register();
        }
    }
}
