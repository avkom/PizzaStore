using System.Collections.Generic;
using System.Web.Mvc;
using PizzaStore.Models;

namespace PizzaStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>
            {
                new ProductViewModel
                {
                    Name = "Product 1 Name",
                    Description = "Product 1 Description"
                },
                new ProductViewModel
                {
                    Name = "Product 2 Name",
                    Description = "Product 2 Description"
                },
                new ProductViewModel
                {
                    Name = "Product 3 Name",
                    Description = "Product 3 Description"
                },
                new ProductViewModel
                {
                    Name = "Product 4 Name",
                    Description = "Product 4 Description"
                },
            };

            return View("Products", products);
        }
    }
}