using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class DatasheetRepository : BaseRepository<Datasheet>, IDatasheetRepository
    {
        public DatasheetRepository(DataContext context) : base(context)
        {
        }

        public bool DatasheetNameExists(string name, Guid? id = null)
        {
            if (id != null)
                return _context.Datasheets.Any(x => x.Name.Equals(name) && x.Id != id);

            return _context.Datasheets.Any(x => x.Name.Equals(name));
        }
    }
}