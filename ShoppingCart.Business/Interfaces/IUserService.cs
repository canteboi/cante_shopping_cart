using System.Collections.Generic;
using ShoppingCart.Model;
using DbUser = ShoppingCart.Data.User;

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
