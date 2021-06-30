using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IDatasheetRepository
    {
        Datasheet Get(Guid id);
        bool DatasheetNameExists(string name);
        void Create(Datasheet datasheet);
        void Delete(Datasheet datasheet);
        void Update(Datasheet datasheet);
    }
}