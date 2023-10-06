using Microsoft.AspNetCore.Mvc;
using Product_Catalog.BLL.Services;

namespace Product_Catalog.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryServices _category;
        IProductServices _product;

        public CategoryController(ICategoryServices category, IProductServices product)
        {
            _category = category;
            _product = product;
        }
        public async Task< IActionResult> GetProdByCatId(int CatId)
        {
            var products =await _category.GetByCatIdBll(CatId);
            return View(products);
        }
    }
}
