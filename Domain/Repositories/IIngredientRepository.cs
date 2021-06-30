using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IIngredientRepository
    {
        Ingredient Get(Guid id);
        List<Ingredient> Get();
        bool IngredientExists(string name);
        bool IngredientInUse(Ingredient ingredient);
        void Create(Ingredient ingredient);
        void Delete(Ingredient ingredient);
        void Update(Ingredient ingredient);
    }
}