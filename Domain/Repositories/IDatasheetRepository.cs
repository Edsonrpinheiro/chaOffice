using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IDatasheetRepository : IBaseRepository<Datasheet>
    {
        bool DatasheetNameExists(string name);
    }
}