using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using BussinessAccess;
using BussinessAccess.Contract;
using CommonData;

namespace Api
{
    public static class DependancyResolverConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<UserManager>().As<IUserManager>();
            //builder.RegisterType<UserManager>().As<IUserManager>();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(a => a.GetCustomAttribute<DependencyRegisterAttribute>() != null)
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            //Creating an Instance for the Mapper
            builder.RegisterInstance(new AutoMapperConfig().Configure()).As<IMapper>();
            var container = builder.Build();
            // Create the dependency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}