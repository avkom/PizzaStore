using Infrastructure.DataAccess;
using PizzaStore.Business.DataAccess.Products;
using PizzaStore.Business.Models;

namespace PizzaStore.Business.Products
{
    public class GetProductsQuery : IGetProductsQuery
    {
        private readonly IUowFactory _uowFactory;
        private readonly IGetProductsDataQuery _getProductsDataQuery;

        public GetProductsQuery(IUowFactory uowFactory, IGetProductsDataQuery getProductsDataQuery)
        {
            _uowFactory = uowFactory;
            _getProductsDataQuery = getProductsDataQuery;
        }

        public ProductListModel Execute(ProductCriteriaModel productCriteria)
        {
            using (_uowFactory.BeginReadOnlyUow())
            {
                return _getProductsDataQuery.Execute(productCriteria);
            }
        }
    }
}
