using System;
using System.Collections.Generic;
using PersonMvvmXF.Entities;

namespace PersonMvvmXF.Data
{
    public interface IRepository<T> where T : IBaseEntity
    {
        bool Persist(T obj);
        IEnumerable<T> GetAll();
        T GetById(Guid key);
        bool Delete(T obj);
        bool DeleteAll();
        void Dispose();
    }
}
