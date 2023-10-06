using Product_Catalog.BOL.Models;

namespace Product_Catalog.DAL.Repositories
{
    public interface IUser
    {
        public  Task<bool> Found(string Email, string password);
        public  Task<User> find(string Email, string password);

    }
}
