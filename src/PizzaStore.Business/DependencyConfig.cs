using PizzaStore.Business.Products;
using SimpleInjector;

namespace PizzaStore.Business
{
    public class DependencyConfig
    {
        public static void RegisterDependencies(Container container)
        {
            container.Register<IGetProductsQuery, GetProductsQuery>();
        }
    }
}