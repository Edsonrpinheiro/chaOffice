using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IDatasheetRepository
    {
        Datasheet Get(Guid id);
        bool DatasheetNameExists(string name);
        void Delete(Datasheet datasheet);
        void Save(Datasheet datasheet);
    }
}