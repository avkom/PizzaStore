using PizzaStore.Business.DataAccess.Products;
using PizzaStore.Business.Models;

namespace PizzaStore.Business.Products
{
    public class GetProductsQuery : IGetProductsQuery
    {
        private readonly IGetProductsDataQuery _getProductsDataQuery;

        public GetProductsQuery(IGetProductsDataQuery getProductsDataQuery)
        {
            _getProductsDataQuery = getProductsDataQuery;
        }

        public ProductListModel Execute(ProductCriteriaModel productCriteria)
        {
            return _getProductsDataQuery.Execute(productCriteria);
        }
    }
}
