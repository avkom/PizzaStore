using System.Web.Mvc;
using Infrastructure.Mapping;
using PizzaStore.Business.Models;
using PizzaStore.Business.Products;
using PizzaStore.Models;

namespace PizzaStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGetProductsQuery _getProductsQuery;

        public ProductsController(IMapper mapper, IGetProductsQuery getProductsQuery)
        {
            _mapper = mapper;
            _getProductsQuery = getProductsQuery;
        }

        public ActionResult Index()
        {
            ProductListModel productsListModel = _getProductsQuery.Execute(new ProductCriteriaModel());
            ProductListViewModel productListViewModel = _mapper.Map<ProductListViewModel>(productsListModel);

            return View("Products", productListViewModel);
        }
    }
}