using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IIngredientRepository
    {
        Ingredient Get(Guid id);
        List<Ingredient> Get();
        bool IngredientExists(string name, Guid? id = null);
        bool IngredientInUse(Ingredient ingredient);
        void Save(Ingredient ingredient);
    }
}