using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using AutoMapper;
using Infrastructure.DataAccess;
using SimpleInjector.Diagnostics;

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
            Infrastructure.DependencyConfig.RegisterDependencies(container);
            DependencyConfig.RegisterDependencies(container);
            Business.DependencyConfig.RegisterDependencies(container);
            DataAccess.DependencyConfig.RegisterDependencies(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingConfig>();
                cfg.AddProfile<DataAccess.MappingConfig>();
            });
            var mapper = new Mapper(mapperConfig);
            container.Register<IMapper>(() => mapper, Lifestyle.Singleton);

            mapperConfig.AssertConfigurationIsValid();

            container
                .GetRegistration(typeof(IUow))
                .Registration
                .SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Disposed explicitly by application code.");

            container
                .GetRegistration(typeof(IAmbientUowProvider))
                .Registration
                .SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Disposed explicitly by application code.");
            container.Verify();
        }
    }
}
