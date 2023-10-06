using Product_Catalog.BOL.Models;

namespace Product_Catalog.DAL.Repositories
{
    public interface ICategory
    {
        public  Task<IQueryable<Category>> GetAll();
        public  Task<List<Product>> GetByCatID(int CatID);
    }
}
