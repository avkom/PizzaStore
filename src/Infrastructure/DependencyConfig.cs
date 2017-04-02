using System.Data;
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
            container.Register<ReadOnlyUow>();
            container.Register<IUow, Uow>();
            container.Register<IAmbientUowProvider, Uow>();
            container.Register<IDbConnectionFactory, DbConnectionFactory>();
            container.Register<IDbConnection>(() => container.GetInstance<IDbConnectionFactory>().CreateConnection());
        }
    }
}