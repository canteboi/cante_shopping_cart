using System.Collections.Generic;
using DbCustomer = ShoppingCart.Data.Customer;
using Customer = ShoppingCart.Model.Customer;

namespace ShoppingCart.Business
{
    interface ICustomerService
    {
        List<Customer> GetCustomers();
        int AddCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
    }
}
