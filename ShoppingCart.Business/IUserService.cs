using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;

namespace ShoppingCart.Business
{
    interface IUserService
    {
        List<User> GetUsers();
        int AddUser();
        void DeleteUser();
        void UpdateUser();
    }
}
