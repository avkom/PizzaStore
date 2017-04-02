using System.Collections.Generic;
using Infrastructure;
using PizzaStore.Business.DataAccess.Products;
using PizzaStore.Business.Models;

namespace PizzaStore.DataAccess.Products
{
    public class GetProductsDataQuery : IGetProductsDataQuery
    {
        private readonly IMapper _mapper;

        public GetProductsDataQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductListModel Execute(ProductCriteriaModel productCriteria)
        {
            List<ProductEntity> products = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Name = "Product 1 Name",
                    Description = "Product 1 Description"
                },
                new ProductEntity
                {
                    Name = "Product 2 Name",
                    Description = "Product 2 Description"
                },
                new ProductEntity
                {
                    Name = "Product 3 Name",
                    Description = "Product 3 Description"
                },
                new ProductEntity
                {
                    Name = "Product 4 Name",
                    Description = "Product 4 Description"
                }
            };

            var productListModel = new ProductListModel
            {
                Products = _mapper.Map<IEnumerable<ProductModel>>(products)
            };

            return productListModel;
        }
    }
}
