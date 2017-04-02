using AutoMapper;
using PizzaStore.Business.Models;
using PizzaStore.DataAccess.Products;

namespace PizzaStore.DataAccess
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProductEntity, ProductModel>();
        }
    }
}