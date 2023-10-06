using Product_Catalog.BOL.Models;

namespace Product_Catalog.DAL.Repositories
{
    public interface IProduct
    {
        public Task<IQueryable<Product>> GetAll();
        public Task<Product> GetById(int id);
        public  Task<IQueryable<Product>> GetAllForAdmin();
        public Task Insert(Product item);

        public Task Update(int id, Product product);
        public Task DeleteById(int id);
    }
}
