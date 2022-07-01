using NetCoreWebApi.Models;
using System.Collections.Generic;

namespace NetCoreWebApi.Services
{
    public interface ICustomerService
    {
        Customer FindCustomerById(int id);
        IEnumerable<Customer> FindCustomerByName(string name);
        IEnumerable<Customer> FindAllCustomers();
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
