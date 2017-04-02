using PizzaStore.Business.Models;

namespace PizzaStore.Business.DataAccess.Products
{
    public interface IGetProductsDataQuery
    {
        ProductListModel Execute(ProductCriteriaModel productCriteria);
    }
}
