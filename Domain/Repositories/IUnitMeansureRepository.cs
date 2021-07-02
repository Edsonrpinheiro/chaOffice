using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUnitMeansureRepository
    {
        UnitMeansure Get(Guid id);
        bool UnitMeansureInUse(UnitMeansure unitMeansure);
        List<UnitMeansure> Get();
        bool UnitMeansureExists(string name, Guid? id = null);
        void Save(UnitMeansure unitMeansure);
    }
}