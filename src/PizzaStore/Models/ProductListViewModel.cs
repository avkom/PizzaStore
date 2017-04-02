using System.Collections.Generic;

namespace PizzaStore.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}