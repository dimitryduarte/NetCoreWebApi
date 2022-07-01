using NetCoreWebApi.Models;
using System.Collections.Generic;

namespace NetCoreWebApi.Repositories
{
    public interface ITelephoneRepository
    {
        IEnumerable<Telephone> GetTelephoneByCustomerId(int customerId);
    }
}
