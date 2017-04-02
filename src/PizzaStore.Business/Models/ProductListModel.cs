using System.Collections.Generic;

namespace PizzaStore.Business.Models
{
    public class ProductListModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
