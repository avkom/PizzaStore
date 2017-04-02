using System.Collections.Generic;
using System.Data;
using Dapper;
using Infrastructure.DataAccess;
using Infrastructure.Mapping;
using PizzaStore.Business.DataAccess.Products;
using PizzaStore.Business.Models;

namespace PizzaStore.DataAccess.Products
{
    public class GetProductsDataQuery : IGetProductsDataQuery
    {
        private readonly IMapper _mapper;
        private readonly IAmbientUowProvider _ambientUowProvider;

        public GetProductsDataQuery(IMapper mapper, IAmbientUowProvider ambientUowProvider)
        {
            _mapper = mapper;
            _ambientUowProvider = ambientUowProvider;
        }

        public ProductListModel Execute(ProductCriteriaModel productCriteria)
        {
            IDbConnection connection = _ambientUowProvider.Get<IDbConnection>();
            string sql = "SELECT * FROM Product;";
            List<ProductEntity> products = connection.Query<ProductEntity>(sql).AsList();
            var productListModel = new ProductListModel
            {
                Products = _mapper.Map<IEnumerable<ProductModel>>(products)
            };

            return productListModel;
        }
    }
}
