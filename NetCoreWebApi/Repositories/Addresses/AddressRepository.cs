using NetCoreWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWebApi.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        public AddressRepository(AppDbContext db)
        {
            _context = db;
        }
        public IEnumerable<Address> GetAddressByCustomerId(int customerId)
        {
            return _context.Address.Where(x => x.CustomerId == customerId).ToList();
        }
    }
}
