using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.ObjectBuilder2;
using PersonMvvmXF.Entities;
using PersonMvvmXF.Ioc;
using SQLite;
using Xamarin.Forms;

namespace PersonMvvmXF.Data
{

    public class Repository<T> : IDisposable, IRepository<T> where T : IBaseEntity, new()
    {
        private readonly SQLiteConnection _connection;

        public Repository()
        {
            _connection = DependencyService.Get<ISqLiteConnection>().GetConnection();
            _connection.CreateTable<Person>();
        }

        public bool Persist(T obj)
        {
            return _connection.Insert(obj) > 0;
        }

        public IEnumerable<T> GetAll()
        {
            return _connection.Table<T>().AsEnumerable();
        }

        public T GetById(Guid id)
        {
            return _connection.Table<T>().AsEnumerable<T>().FirstOrDefault(c => c.Id.Equals(id));
        }
        
        public bool Delete(T obj)
        {
            return _connection.Delete(obj) > 0 ;
        }

        public bool DeleteAll()
        {
            return _connection.DeleteAll<T>() > 0;
        }
        
        public void Dispose()
        {
            _connection.Dispose();
        }
        
    }
}
