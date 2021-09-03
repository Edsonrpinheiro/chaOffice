using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {   
        protected readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public T Get(Guid id) => _context.Set<T>().Find(id);

        public List<T> Get() => _context.Set<T>().AsNoTracking().ToList();

        public int Save() =>_context.SaveChanges();

        public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;
    }
}