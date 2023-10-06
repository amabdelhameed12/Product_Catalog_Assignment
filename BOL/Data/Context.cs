using Microsoft.EntityFrameworkCore;

using Product_Catalog.BOL.Models;
using System.Data.Common;

using Microsoft.Extensions.Configuration.Json;

using Microsoft.Extensions.Configuration;

namespace Product_Catalog.BOL.Data
{
    public class Context:DbContext
    {

        public Context() : base()
        {

        }

        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Category>().HasData(
                new Category {Id=1 , Name = "Mobiles"},
                new Category {Id=2, Name = "Pcs" },
                new Category {Id=3, Name = "Electronics" }
            );
            modelBuilder.Entity<Product>()
             .Property(p => p.IsDeleted)
             .HasDefaultValue(false);
        }
    }
}
