﻿using Microsoft.EntityFrameworkCore;
using NetCoreWebApi.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWebApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        public DbSet<T> table;
        public readonly Logger _logger;
        public Repository(AppDbContext db)
        {
            _db = db;
            table = _db.Set<T>();
            _logger = LogManager.GetCurrentClassLogger();
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return table.ToList();
            }
            catch
            {
                throw new Exception($"Não foi possível recuperar os dados do cliente, tente novamente.");
            }
        }
        public T GetById(object id)
        {
            try
            {
                return table.Find(id);
            }
            catch (Exception ex)
            {
                _logger.Error((ex.InnerException ?? ex).Message);
                throw new Exception((ex.InnerException ?? ex).Message);
            }
        }
        public void Insert(T obj)
        {
            try
            {
                table.Add(obj);
                Save();
            }
            catch (Exception ex)
            {
                _logger.Error((ex.InnerException ?? ex).Message);
                throw new Exception((ex.InnerException ?? ex).Message);
            }
        }
        public void Update(T obj)
        {
            try
            {
                table.Attach(obj);
                _db.Entry(obj).State = EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            {
                _logger.Error((ex.InnerException ?? ex).Message);
                throw new Exception((ex.InnerException ?? ex).Message);
            }

        }
        public void Delete(object id)
        {
            try
            {
                T existing = table.Find(id);

                if (existing == null)
                    throw new Exception($"Registro não encontrado, não foi possível deletar o registro.");

                table.Remove(existing);
                _db.SaveChanges();
                Save();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw new Exception((ex.InnerException ?? ex).Message);
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public bool Exists(int id)
        {
            return table.Find(id) != null ? true : false;
        }
    }
}
