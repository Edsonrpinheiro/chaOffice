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
            if(id != null)
                return _context.Categories.Any(x => x.Name == name && x.Id != id);

            return _context.Categories.Any(x => x.Name == name);
        }

        public bool CategoryInUse(Category category)
        {
            return _context.Categories.Any(x => x == category);
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public Category Get(Guid id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public List<Category> Get()
        {
            return _context.Categories
                   .Where(c => c.Active == true)
                   .AsNoTracking()
                   .ToList();
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}