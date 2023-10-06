using Product_Catalog.BOL.Models;
using Product_Catalog.DAL.Repositories;
using Product_Catalog.DTO;

namespace Product_Catalog.BLL.Services
{
    public class ProductServices:IProductServices
    {
        private readonly IProduct _product;
        ProductDTO productDTO;
        public ProductServices(IProduct product)
        {
            productDTO = new ProductDTO();
            _product=product;
        }
        public async Task<List<ProductDTO>> GetAllBll()
        {
            var AllProducts = await _product.GetAll();
            List<ProductDTO> productDTOList = new List<ProductDTO>();

            foreach (var product in AllProducts)
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

            return productDTOList.ToList();
        }

        public async Task< ProductDTO> GetByIdBll(int id)
        {
            Product prd = await  _product.GetById(id);
            productDTO.Name= prd.Name;
            productDTO.Id = prd.Id;
            productDTO.Price = prd.Price;
            productDTO.IsDeleted = prd.IsDeleted;
            productDTO.CreationDate= prd.CreationDate;
            productDTO.Duration= prd.Duration;
            productDTO.StartDate= prd.StartDate;
            productDTO.CreatedByUserId = prd.CreatedByUserId;
            productDTO.Cat_Id= prd.Cat_Id;
       
            return productDTO;
        }
        public async Task<List<ProductDTO>> GetAllForAdminBll()
        {
            var AllProducts = await _product.GetAllForAdmin();
            List<ProductDTO> productList = new List<ProductDTO>();

            foreach (var productDTO in AllProducts)
            {
                ProductDTO product = new ProductDTO
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    CreationDate = productDTO.CreationDate,
                    Duration = productDTO.Duration,
                    StartDate = productDTO.StartDate,
                    Cat_Id = productDTO.Cat_Id,
                    IsDeleted = productDTO.IsDeleted,
                    CreatedByUserId = productDTO.CreatedByUserId
                };

                productList.Add(product);
            }
            return productList;
        }


        public async Task InsertBll(ProductDTO prd)
        {
            Product product = new Product
            {
                Id = prd.Id,
                Name = prd.Name,
                Price = prd.Price,
                CreationDate = prd.CreationDate,
                Duration = prd.Duration,
                StartDate = prd.StartDate,
                Cat_Id = prd.Cat_Id,
                IsDeleted = prd.IsDeleted,
                CreatedByUserId = prd.CreatedByUserId
            };

            await _product.Insert(product);
        }
        public async Task UpdateBll(int id, ProductDTO prd)
        {
            Product product = new Product
            {
                Id = prd.Id,
                Name = prd.Name,
                Price = prd.Price,
                CreationDate = prd.CreationDate,
                Duration = prd.Duration,
                StartDate = prd.StartDate,
                Cat_Id = prd.Cat_Id,
                IsDeleted = prd.IsDeleted,
                CreatedByUserId = prd.CreatedByUserId
            };
            await _product.Update(id, product);

        }
        public async Task DeleteByIdBll(int id)
        {
           await _product.DeleteById(id);
        }

      
     
    }

   
}
