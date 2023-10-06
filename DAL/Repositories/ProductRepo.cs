using Microsoft.EntityFrameworkCore;
using Product_Catalog.BOL.Models;
using Product_Catalog.BOL.Data;

namespace Product_Catalog.DAL.Repositories
{
    public class ProductRepo:IProduct
    {
        Context context;
        public ProductRepo()
        {
            context = new Context();
        }
        public async Task <IQueryable <Product>> GetAll()
        {


            var currentTime = DateTime.Now;
            var products= await context.Products.Where(p => !p.IsDeleted)
                .Where(p => p.StartDate <= currentTime && currentTime <= p.StartDate.AddMonths(p.Duration)).ToListAsync();
            return products.AsQueryable(); 
        }
        public async Task<Product> GetById(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }
        public async Task<IQueryable<Product>> GetAllForAdmin()
        {
            var products = await context.Products.Where(p => !p.IsDeleted).ToListAsync();
            return products.AsQueryable();
        }

        public async Task Insert(Product item)
        {
            context.Products.Add(item);
            context.SaveChanges();
        }
        public async Task Update(int id, Product product)
        {
            //Using ExecuteUpdate
            context.Products.Where(p => p.Id == id)
            .ExecuteUpdate(setters => setters
            .SetProperty(p => p.Name, product.Name)
            .SetProperty(p => p.CreationDate, product.CreationDate)
            .SetProperty(p => p.CreatedByUserId, product.CreatedByUserId)
            .SetProperty(p => p.StartDate, product.StartDate)
            .SetProperty(p => p.Price, product.Price)
            .SetProperty(p => p.Duration, product.Duration)
            .SetProperty(p => p.IsDeleted, product.IsDeleted));

        }
        public async Task DeleteById(int id)
        {

            Product product =  await GetById(id);
     
            if (product != null && !product.IsDeleted)
            {
                product.IsDeleted = true;
                Update(id, product);
                context.SaveChanges();
            }

            // Or  => Using Hard Delete By ExecuteDelete
            //context.Products.Where(b => b.Id == id).ExecuteDelete();
        }

      
     
    }

}
