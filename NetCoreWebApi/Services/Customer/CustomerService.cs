using NetCoreWebApi.Models;
using NetCoreWebApi.Repositories;
using System;
using System.Collections.Generic;

namespace NetCoreWebApi.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        private IRepository<Customer> _repository = null;
        private ICustomerRepository _customerRepository = null;

        public CustomerService()
        {
            this._repository = new Repository<Customer>(_context);
            this._customerRepository = new CustomerRepository(_context);
        }

        public CustomerService(Repository<Customer> repository, CustomerRepository customerRepository)
        {
            this._repository = repository;
            this._customerRepository = customerRepository;
        }

        public Customer FindCustomerById(int id)
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

        public IEnumerable<Customer> FindCustomerByName(string name)
        {
            try
            {
                return _customerRepository.GetCustomerByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível recuperar os dados, tente novamente. Motivo: {ex.Message}");
            }
        }

        public IEnumerable<Customer> FindAllCustomers()
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

        public void InsertCustomer(Customer customer)
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

        public void UpdateCustomer(Customer customer)
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

        public void DeleteCustomer(int id)
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

        public bool CustomerExists(int id)
        {
            try
            {
                return _repository.Exists(id);
            }
            catch
            {
                return false;
            }
        }

    }
}
