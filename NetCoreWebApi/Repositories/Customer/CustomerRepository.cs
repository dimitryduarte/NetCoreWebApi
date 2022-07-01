using NetCoreWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWebApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext db)
        {
            _context = db;
        }
        public IEnumerable<Customer> GetCustomerByName(string name)
        {
            return _context.Customers.Where(x => x.Name.Contains(name)).ToList();
        }
    }
}
