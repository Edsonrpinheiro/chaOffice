using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Category Get(Guid id);
        List<Category> Get();
        bool CategoryExists(string name, Guid? id = null);
        bool CategoryInUse(Category category);
        void Create(Category category);
        void Save(Category category);
    }
}