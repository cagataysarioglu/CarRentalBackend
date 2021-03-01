using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Abstract;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Func<T, bool> filter = null);
        T Get(Func<T, bool> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
