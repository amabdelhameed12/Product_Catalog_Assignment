using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
//using Product_Catalog.PresentationLayer;
using Product_Catalog.BLL.Services;
using Product_Catalog.BOL.Models;
//using Product_Catalog.PresentationLayer.ViewModels;
using Product_Catalog.DTO;

namespace Product_Catalog.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ProductController : Controller
    {
        private readonly IProductServices _product;
        private readonly ICategoryServices _category;

        public ProductController(IProductServices product , ICategoryServices category)
        { 
            _product=product;
            _category=category;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> New()
        {
            var categories =await _category.GetAllCategoriesBll();
            ViewBag.Cat = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult New(CreateProductViewModel createProductView)
        {
            if (ModelState.IsValid == true)
            {
                ProductDTO product = new ProductDTO();
                product.Name = createProductView.Name;
                product.CreationDate = createProductView.CreationDate;
                product.StartDate = createProductView.StartDate;
                product.Duration = createProductView.Duration;
                product.Price = createProductView.Price;
                product.Cat_Id = createProductView.Category_Id;
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");

                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                    int userId = Convert.ToInt32(userIdValue);
                    product.CreatedByUserId = userId;
                }
              
                _product.InsertBll(product);
                return RedirectToAction("Index" , "Home");
            }
      

            return View("New", createProductView);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _product.GetByIdBll(id);
            if (product == null)
            {
                return NotFound();
            }
            var viewModel = new EditProductViewModel
            {
                Name = product.Name,
                CreationDate = product.CreationDate,
                CreatedByUserId = product.CreatedByUserId,
                StartDate = product.StartDate,
                Duration = product.Duration,
                Price = product.Price,
                Category_Id = product.Cat_Id
     
            };
            return View(viewModel);
        }

        [HttpPost]
       

        public async Task<IActionResult> Edit(int id, EditProductViewModel viewModel)
        {
            ProductDTO product = await _product.GetByIdBll(id);
            if (product == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                product.Name = viewModel.Name;
                product.CreationDate = viewModel.CreationDate;
                product.CreatedByUserId = viewModel.CreatedByUserId;
                product.StartDate = viewModel.StartDate;
                product.Duration = viewModel.Duration;
                product.Price = viewModel.Price;
                product.Cat_Id = viewModel.Category_Id;
                product.IsDeleted = false;
                _product.UpdateBll(id, product);
                return RedirectToAction("Index" , "Home");
            }

            return View(viewModel);
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            _product.DeleteByIdBll(id);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var product =  await _product.GetByIdBll(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


    }
}
