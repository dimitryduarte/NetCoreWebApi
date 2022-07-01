using NetCoreWebApi.Models;
using System.Collections.Generic;

namespace NetCoreWebApi.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomerByName(string name);
    }
}
