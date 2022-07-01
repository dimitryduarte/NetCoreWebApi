using NetCoreWebApi.Models;
using System.Collections.Generic;

namespace NetCoreWebApi.Services
{
    public interface IAddressService
    {
        Address FindAddressById(int id);
        IEnumerable<Address> FindAllAddresses();
        IEnumerable<Address> FindAddressByCustomerId(int id);
        void InsertAddress(Address customer);
        void UpdateAddress(Address customer);
        void DeleteAddress(int id);
    }
}
