using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IDatasheetItemRepository
    {
        DatasheetItem Get(Guid id);
        void Create(DatasheetItem datasheetItem);
        void Delete(DatasheetItem datasheetItem);
        void Update(DatasheetItem datasheetItem);
    }
}