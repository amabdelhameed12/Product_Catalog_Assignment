using Product_Catalog.BOL.Models;
using Product_Catalog.DTO;

namespace Product_Catalog.BLL.Services
{
    public interface ICategoryServices
    {
        public Task<List<CategoryDTO>> GetAllCategoriesBll();
        public Task<List<ProductDTO>> GetByCatIdBll(int CatID);

    }
}
