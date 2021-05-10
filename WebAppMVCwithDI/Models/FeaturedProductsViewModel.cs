using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVCwithDI.Models
{
    public class FeaturedProductsViewModel
    {
        public IEnumerable<ProductViewModel> Products { get;}
        public FeaturedProductsViewModel(IEnumerable<ProductViewModel> products)
        {
            this.Products = products;
        }
    }
}
