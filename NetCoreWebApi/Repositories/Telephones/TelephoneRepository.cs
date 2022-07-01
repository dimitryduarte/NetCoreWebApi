using NetCoreWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWebApi.Repositories
{
    public class TelephoneRepository : ITelephoneRepository
    {
        private readonly AppDbContext _context;
        public TelephoneRepository(AppDbContext db)
        {
            _context = db;
        }
        public IEnumerable<Telephone> GetTelephoneByCustomerId(int customerId)
        {
            return _context.Telephone.Where(x => x.CustomerId == customerId).ToList();
        }
    }
}
