using AutoMapper;
using PizzaStore.Business.Models;
using PizzaStore.Models;

namespace PizzaStore
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ProductModel, ProductViewModel>();
            CreateMap<ProductListModel, ProductListViewModel>();
        }
    }
}