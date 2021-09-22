using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }

        public bool CategoryExists(string name, Guid? id = null)
        {
            if (id != null)
                return _context.Categories.Any(x => x.Name.Equals(name) && x.Id != id && x.Active == true);

            return _context.Categories.Any(x => x.Name.Equals(name) && x.Active == true);
        }

        public bool CategoryInUse(Category category)
        {
            return _context.Products.Any(x => x.Category == category);
        }

        public List<Category> GetActives()
        {
            return _context.Categories.Where(x => x.Active).AsNoTracking().ToList();
        }
    }
}