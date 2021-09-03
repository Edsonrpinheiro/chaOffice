using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        bool CategoryExists(string name, Guid? id = null);
        bool CategoryInUse(Category category);
    }
}