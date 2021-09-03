using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(Guid id);
        List<T> Get();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Save();
    }
}