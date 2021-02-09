using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Func<T, bool> filter = null);
        List<T> GetCarsByBrandId(Func<T, bool> filter);
        List<T> GetCarsByColorId(Func<T, bool> filter);
        T Get(Func<T, bool> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
