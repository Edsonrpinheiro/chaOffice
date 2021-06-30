using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUnitMeansureRepository
    {
        UnitMeansure Get(Guid id);
        List<UnitMeansure> Get();
        bool UnitMeansureExists(string name);
        bool IsUnitMeansureUsed(UnitMeansure unitMeansure);
        void Create(UnitMeansure unitMeansure);
        void Delete(UnitMeansure unitMeansure);
        void Update(UnitMeansure unitMeansure);
    }
}