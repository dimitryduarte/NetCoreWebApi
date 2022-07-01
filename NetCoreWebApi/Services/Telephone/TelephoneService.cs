using NetCoreWebApi.Models;
using NetCoreWebApi.Repositories;
using System;
using System.Collections.Generic;

namespace NetCoreWebApi.Services
{
    public class TelephoneService : ITelephoneService
    {

        private readonly AppDbContext _context;

        public TelephoneService(AppDbContext context)
        {
            _context = context;
        }

        private IRepository<Telephone> _repository = null;
        private TelephoneRepository _telephoneRepository = null;

        public TelephoneService()
        {
            this._repository = new Repository<Telephone>(_context);
            this._telephoneRepository = new TelephoneRepository(_context);
        }

        public TelephoneService(Repository<Telephone> repository, TelephoneRepository telephoneRepository)
        {
            this._repository = repository;
            this._telephoneRepository = telephoneRepository;
        }

        public Telephone FindTelephoneById(int id)
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

        public IEnumerable<Telephone> FindTelephoneByCustomerId(int id)
        {
            try
            {
                return _telephoneRepository.GetTelephoneByCustomerId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível recuperar os dados, tente novamente. Motivo: {ex.Message}");
            }
        }

        public IEnumerable<Telephone> FindAllTelephones()
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

        public void InsertTelephone(Telephone customer)
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

        public void UpdateTelephone(Telephone customer)
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

        public void DeleteTelephone(int id)
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
