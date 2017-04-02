using PizzaStore.Business.DataAccess.Products;
using PizzaStore.DataAccess.Products;
using SimpleInjector;

namespace PizzaStore.DataAccess
{
    public class DependencyConfig
    {
        public static void RegisterDependencies(Container container)
        {
            container.Register<IGetProductsDataQuery, GetProductsDataQuery>();
        }
    }
}