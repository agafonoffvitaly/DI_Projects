using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebAppMVCwithDI.Models;

namespace WebAppMVCwithDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult Index()
        {
#if DEBUG
            //Заглушка на этапе разработки 
            var vm = new FeaturedProductsViewModel(new[]
            {
                new ProductViewModel("Chocolate", 34.95m),
                new ProductViewModel("Asparagus", 39.80m),
            });
#else
            IEnumerable<DiscountedProduct> products = this.productService.GetFeaturedProducts();
            var vm = new FeaturedProductsViewModel(from product in products
                                                   select new ProductViewModel(product));
#endif
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
