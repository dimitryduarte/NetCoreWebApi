using NetCoreWebApi.Models;
using System.Collections.Generic;

namespace NetCoreWebApi.Controllers
{
    public class CustomerDTO
    {
        public Customer Customer { get; set; }

        public IEnumerable<Telephone> Telephone { get; set; }

        public IEnumerable<Address> Address { get; set; }
    }
}
