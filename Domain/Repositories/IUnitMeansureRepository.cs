using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUnitMeansureRepository : IBaseRepository<UnitMeansure>
    {
        bool UnitMeansureInUse(UnitMeansure unitMeansure);
        bool UnitMeansureExists(string name, Guid? id = null);
    }
}