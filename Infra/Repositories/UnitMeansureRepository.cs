using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UnitMeansureRepository : BaseRepository<UnitMeansure>, IUnitMeansureRepository
    {
        public UnitMeansureRepository(DataContext context) : base(context)
        {
        }

        public bool UnitMeansureExists(string name, Guid? id = null)
        {
            if (id != null)
                return _context.UnitMeasures.Any(x => x.Name.Equals(name) && x.Id != id && x.Status == true);

            return _context.UnitMeasures.Any(x => x.Name.Equals(name) && x.Status == true);
        }

        public bool UnitMeansureInUse(UnitMeansure unitMeansure)
        {
            return _context.Ingredients.Any(x => x.UnitMeansure == unitMeansure);
        }

        public List<UnitMeansure> GetActives()
        {
            return _context.UnitMeasures.Where(x => x.Status).AsNoTracking().ToList();
        }
    }
}