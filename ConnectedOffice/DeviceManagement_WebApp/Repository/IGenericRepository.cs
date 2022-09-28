using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        //This interface Abstract the implementation,
        //it inherits all the methods. Used by all entities to interact with DbContext.
        T GetById(Guid? id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        bool Exists(Guid? id);
    }

}
