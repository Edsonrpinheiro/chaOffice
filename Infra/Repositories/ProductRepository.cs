using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public List<Product> Get()
        {
            return _context.Products
                   .AsNoTracking()
                   .ToList();
        }

        public bool ProductExists(string name, Guid? id = null)
        {
            if (id != null)
                return _context.Products.Any(p => p.Name == name && p.Id != id);

            return _context.Products.Any(p => p.Name == name);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}