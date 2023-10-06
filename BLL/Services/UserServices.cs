
using Product_Catalog.BOL.Models;
using Product_Catalog.DAL.Repositories;
using Product_Catalog.DTO;

namespace Product_Catalog.BLL.Services
{
    public class UserServices:IUserServices
    {
        private readonly IUser _user;

        public UserServices(IUser user )
        {
            _user=user;
        }
        public async Task< bool> FoundBll(string Email, string password)
        {
            bool result= await _user.Found(Email, password);
            return result;
        }
    
        public async Task<UserDTO> FindBll(string Email, string password)
        {
            User user = await _user.find(Email, password);

            if (user != null)
            {
                UserDTO userDTO = new UserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role
                };

                return userDTO;
            }

            return null;
        }



    }
}
