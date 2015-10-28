using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using ShoppingCart.Data;
using Customer = ShoppingCart.Model.Customer;
using DbCustomer = ShoppingCart.Data.Customer;


namespace ShoppingCart.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ShoppingCartDbEntities _dbEntities;

        public CustomerService()
        {
            _dbEntities = new ShoppingCartDbEntities();
        }

        public Customer GetCustomer(string emailAddress)
        {
            try
            {
                var dbcustomer = _dbEntities.Customers.SingleOrDefault(x => String.Equals(x.email, emailAddress, StringComparison.CurrentCultureIgnoreCase));

                if (dbcustomer == null)
                {
                    throw new ObjectNotFoundException(string.Format("Customer with emailaddress of :{0} was not found", emailAddress));
                }

                return new Customer()
                {
                    CartId = dbcustomer.cart_id,
                    CustomerId = dbcustomer.customer_id,
                    Email = dbcustomer.email,
                    Firstname = dbcustomer.firstname,
                    Lastname = dbcustomer.lastname,
                    Password = dbcustomer.password,
                    Salt = dbcustomer.salt,
                    Status = dbcustomer.status,
                    Telephone = dbcustomer.telephone,
                    DateAdded = dbcustomer.date_added
                };
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public int AddCustomer(Customer customer)
        {
            try
            {
                var dbcustomer = new DbCustomer
                {
                    cart_id = customer.CartId,
                    email = customer.Email,
                    firstname = customer.Firstname,
                    lastname = customer.Lastname,
                    password = customer.Password,
                    salt = customer.Salt,
                    status = customer.Status,
                    token = customer.Token,
                    telephone = customer.Telephone,
                    date_added = DateTime.Now
                };

                dbcustomer = _dbEntities.Customers.Add(dbcustomer);
                _dbEntities.SaveChanges();

                return dbcustomer.customer_id;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public void DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
