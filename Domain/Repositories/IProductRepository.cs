using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        bool ProductExists(string name, Guid? id = null);
    }
}