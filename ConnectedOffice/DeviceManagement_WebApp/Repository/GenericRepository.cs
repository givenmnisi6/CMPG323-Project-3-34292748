using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using DeviceManagement_WebApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    //This class implements all methods
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        //Add method, after adding it save the changes
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChangesAsync();
        }
        //Getting all the items in the list
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        //Getting each item by its ID
        public T GetById(Guid? id)
        {
            return _context.Set<T>().Find(id);
        }
        //Remove method, after deleting it save the changes
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
        }
        //Update method
        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChangesAsync();
        }
        //This method checks whether the item exists, and returns a true/false
        public bool Exists(Guid? id)
        {
            return _context.Set<T>().Find(id) != null;
        }

    }
}


