using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ProductRepository :BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
        
        public bool ProductExists(string name, Guid? id = null)
        {
            if (id != null)
                return _context.Products.Any(p => p.Name.Equals(name)  && !p.Id.Equals(id));

            return _context.Products.Any(p => p.Name.Equals(name));
        }
    }
}