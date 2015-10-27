using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbUser = ShoppingCart.Data.User;
using User = ShoppingCart.Model.User;

namespace ShoppingCart.Business
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public int AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
