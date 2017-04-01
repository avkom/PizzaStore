using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace PizzaStore
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DependencyConfig.RegisterDependencies(container);
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
