using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        bool IngredientExists(string name, Guid? id = null);
        bool IngredientInUse(Ingredient ingredient);
        List<Ingredient> GetActives();
    }
}