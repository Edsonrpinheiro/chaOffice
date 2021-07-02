using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        List<Product> Get();
        bool ProductExists(string name);
        void Save(Product product);
    }
}