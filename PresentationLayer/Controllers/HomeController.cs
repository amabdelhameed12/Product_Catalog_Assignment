using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using Product_Catalog.BLL.Services;
using Product_Catalog.BOL.Models;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _product;

        public HomeController(ILogger<HomeController> logger , IProductServices product)
        {
            _logger = logger;
            _product= product;
        }

        public async Task<IActionResult> Index()
        {
           if (User.IsInRole("Admin"))
            {
                var allPrds= await _product.GetAllForAdminBll();
                return View(allPrds);
            }
            var allProducts = await _product.GetAllBll();
            return View(allProducts);
          
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