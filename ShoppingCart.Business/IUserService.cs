using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;
using DbUser = ShoppingCart.Data.User;
using User = ShoppingCart.Model.User;

namespace ShoppingCart.Business
{
    interface IUserService
    {
        List<User> GetUsers();
        int AddUser(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
    }
}
