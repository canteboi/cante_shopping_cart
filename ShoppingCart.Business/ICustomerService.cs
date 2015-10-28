using System.Collections.Generic;
using DbCustomer = ShoppingCart.Data.Customer;
using Customer = ShoppingCart.Model.Customer;

namespace ShoppingCart.Business
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(string emailAddress);
        int AddCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
    }
}
