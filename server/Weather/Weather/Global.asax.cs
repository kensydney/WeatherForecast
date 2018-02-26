using System.Web.Mvc;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace Weather
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = BuildAutofacContainer();
            var dependencyResolver = new AutofacDependencyResolver(container);

            DependencyResolver.SetResolver(dependencyResolver);
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }

        protected IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();

            var module = new AutofacModule();
            builder.RegisterModule(module);
            var container = builder.Build();
            return container;
        }
    }
}
