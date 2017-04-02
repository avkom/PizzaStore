using PizzaStore.Business.Models;

namespace PizzaStore.Business.Products
{
    public interface IGetProductsQuery
    {
        ProductListModel Execute(ProductCriteriaModel productCriteria);
    }
}
