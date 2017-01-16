using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
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

                var builder = new ContainerBuilder();
                builder.RegisterApiControllers(this.GetType().Assembly);
                var container = builder.Build();

                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            });
        }
    }
}
