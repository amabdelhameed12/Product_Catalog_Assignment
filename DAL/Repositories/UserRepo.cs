using Microsoft.EntityFrameworkCore;
using Product_Catalog.BOL.Data;
using Product_Catalog.BOL.Models;

namespace Product_Catalog.DAL.Repositories
{
    public class UserRepo:IUser
    {
        Context context;
        public UserRepo( )
        {
            context = new Context();
        }
        public async Task< bool> Found(string Email, string password)
        {
            var found = context.Users.FirstOrDefault(a => a.Email == Email && a.Password == password);
            if (found != null)
            {

                return true;
            }
            return false;
        }
        public async Task< User> find(string Email, string password)

              {
            User acount = await  context.Users.FirstOrDefaultAsync(a => a.Email == Email && a.Password == password);
            return acount;
        }



}
}
