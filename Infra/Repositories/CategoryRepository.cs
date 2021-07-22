using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {   
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(string name, Guid? id = null)
        {
            throw new NotImplementedException();
        }

        public bool CategoryInUse(Category category)
        {
            throw new NotImplementedException();
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
        }

        public Category Get(Guid id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public List<Category> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}