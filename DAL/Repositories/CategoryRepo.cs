
using Product_Catalog.BOL.Models;
using Product_Catalog.BOL.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Product_Catalog.DAL.Repositories
{
    public class CategoryRepo:ICategory
    {
        Context context;
        private readonly IProduct _product;

        public CategoryRepo(IProduct product)
        {
            context = new Context();
            _product = product;
        }

        public async Task<IQueryable<Category>> GetAll()
        {
            var categories = await context.Categories.ToListAsync();
            return categories.AsQueryable();
        }
        public async Task<List<Product>> GetByCatID(int CatID)
        {
             
           var products =  await _product.GetAll();
            return products.Where(e => e.Cat_Id == CatID).ToList();
        }

    }
}
