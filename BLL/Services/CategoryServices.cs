
using Product_Catalog.BOL.Models;
using Product_Catalog.DAL.Repositories;
using Product_Catalog.DTO;

namespace Product_Catalog.BLL.Services
{
    public class CategoryServices:ICategoryServices
    {
        private readonly ICategory _category;
        private readonly IProduct _product;

        public CategoryServices(ICategory category , IProduct product  )
        {
            _category=category;
            _product = product;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesBll()
        {
            var categories = await _category.GetAll();
            List<CategoryDTO> categoryDTOList = new List<CategoryDTO>();

            foreach (var category in categories)
            {
                CategoryDTO categoryDTO = new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name
                };

                categoryDTOList.Add(categoryDTO);
            }
            return categoryDTOList;
        }

        public async Task<List<ProductDTO>> GetByCatIdBll(int CatID)
        {
            var prds = await _category.GetByCatID(CatID);
            List<ProductDTO> productDTOList = new List<ProductDTO>();

            foreach (var product in prds)
            {
                ProductDTO productDTO = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CreationDate = product.CreationDate,
                    Duration = product.Duration,
                    StartDate = product.StartDate,
                    Cat_Id = product.Cat_Id,
                    IsDeleted = product.IsDeleted,
                    CreatedByUserId = product.CreatedByUserId
                };

                productDTOList.Add(productDTO);
            }
            return productDTOList;
        }


    }
}
