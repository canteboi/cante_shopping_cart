using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Data;

namespace ShoppingCart.Business
{
    interface ICustomerService
    {
        List<Customer> GetCustomers();
        int AddCustomer();
        void DeleteCustomer();
        void UpdateCustomer();
    }
}
