using System;
using System.Linq;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class DatasheetItemRepository : BaseRepository<DatasheetItem>, IDatasheetItemRepository
    {
        public DatasheetItemRepository(DataContext context) : base(context)
        {
        }
    }
}