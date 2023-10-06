using Product_Catalog.BOL.Models;
using Product_Catalog.DTO;

namespace Product_Catalog.BLL.Services
{
    public interface IUserServices
    {
        public  Task<bool> FoundBll(string Email, string password);
        public  Task<UserDTO> FindBll(string Email, string password);

    }
}
