using SimpleInjector;

namespace PizzaStore
{
    public class DependencyConfig
    {
        public static void RegisterDependencies(Container container)
        {
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}