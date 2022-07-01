using NetCoreWebApi.Models;
using System.Collections.Generic;

namespace NetCoreWebApi.Services
{
    public interface ITelephoneService
    {
        Telephone FindTelephoneById(int id);
        IEnumerable<Telephone> FindAllTelephones();
        IEnumerable<Telephone> FindTelephoneByCustomerId(int id);
        void InsertTelephone(Telephone customer);
        void UpdateTelephone(Telephone customer);
        void DeleteTelephone(int id);
    }
}
