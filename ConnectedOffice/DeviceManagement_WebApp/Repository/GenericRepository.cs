﻿using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using DeviceManagement_WebApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChangesAsync();
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(Guid? id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
        }
 
        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChangesAsync();
        }

        public bool Exists(Guid? id)
        {
            return _context.Set<T>().Find(id) != null;
        }

    }
}


