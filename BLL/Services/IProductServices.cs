using Product_Catalog.BOL.Models;
using Product_Catalog.DTO;

namespace Product_Catalog.BLL.Services
{
    public interface IProductServices
    {
        public  Task<List<ProductDTO>> GetAllBll();
        public Task<ProductDTO> GetByIdBll(int id);
        public Task<List<ProductDTO>> GetAllForAdminBll();
        public Task InsertBll(ProductDTO prd);
        public Task UpdateBll(int id, ProductDTO prd);
    
        public Task DeleteByIdBll(int id);
       
    }
}
