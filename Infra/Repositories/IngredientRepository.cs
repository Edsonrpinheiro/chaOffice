using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(DataContext context) : base(context)
        {
        }

        public bool IngredientExists(string name, Guid? id = null)
        {
            if (id != null)
                return _context.Ingredients.Any(x => x.Name.Equals(name) && x.Id != id && x.Status == true);

            return _context.Ingredients.Any(x => x.Name.Equals(name) && x.Status == true);
        }

        public bool IngredientInUse(Ingredient ingredient)
        {
            return _context.DatasheetItems.Any(x => x.Ingredient == ingredient);
        }

        public List<Ingredient> GetActives()
        {
            return _context.Ingredients.Where(x => x.Status).AsNoTracking().ToList();
        }

    }
}