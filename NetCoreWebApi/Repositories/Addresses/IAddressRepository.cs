using NetCoreWebApi.Models;
using System.Collections.Generic;

namespace NetCoreWebApi.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddressByCustomerId(int customerId);
    }
}
