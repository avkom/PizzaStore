using Infrastructure.DataAccess;
using Infrastructure.Mapping;
using SimpleInjector;

namespace Infrastructure
{
    public class DependencyConfig
    {
        public static void RegisterDependencies(Container container)
        {
            container.Register<IMapper, Mapper>();
            container.Register<IUowFactory, UowFactory>();
            container.Register<IUow, Uow>();
            container.Register<IAmbientUowProvider, Uow>();
        }
    }
}