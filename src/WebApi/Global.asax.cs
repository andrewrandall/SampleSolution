using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Sample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();

                config.Filters.Add(new BusinessRuleExceptionFilter());

                var builder = new ContainerBuilder();
                builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
                builder.RegisterModule(new InMemoryStorageModule());
                builder.RegisterModule(new CoreModule());
                var container = builder.Build();

                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            });
        }
    }
}
