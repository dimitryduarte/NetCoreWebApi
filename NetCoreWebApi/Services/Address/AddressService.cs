using NetCoreWebApi.Models;
using NetCoreWebApi.Repositories;
using System;
using System.Collections.Generic;

namespace NetCoreWebApi.Services
{
    public class AddressService : IAddressService
    {

        private readonly AppDbContext _context;

        public AddressService(AppDbContext context)
        {
            _context = context;
        }

        private IRepository<Address> _repository = null;
        private AddressRepository _addressRepository = null;

        public AddressService()
        {
            this._repository = new Repository<Address>(_context);
            this._addressRepository = new AddressRepository(_context);
        }

        public AddressService(Repository<Address> repository, AddressRepository addressRepository)
        {
            this._repository = repository;
            this._addressRepository = addressRepository;
        }

        public Address FindAddressById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível recuperar os dados, tente novamente. Motivo: {ex.Message}");
            }
        }
        public IEnumerable<Address> FindAddressByCustomerId(int id)
        {
            try
            {
                return _addressRepository.GetAddressByCustomerId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível recuperar os dados, tente novamente. Motivo: {ex.Message}");
            }
        }

        public IEnumerable<Address> FindAllAddresses()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível recuperar os dados, tente novamente. Motivo: {ex.Message}");
            }
        }

        public void InsertAddress(Address customer)
        {
            try
            {
                _repository.Insert(customer);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível inserir os dados, tente novamente. Motivo: {ex.Message}");
            }
        }

        public void UpdateAddress(Address customer)
        {
            try
            {
                _repository.Update(customer);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível atualizar os dados, tente novamente. Motivo: {ex.Message}");
            }
        }

        public void DeleteAddress(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível excluir os dados, tente novamente. Motivo: {ex.Message}");
            }
        }


    }
}
