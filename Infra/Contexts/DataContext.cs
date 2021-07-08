using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Datasheet> Datasheets { get; set; }
        public DbSet<DatasheetItem> DatasheetItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UnitMeansure> UnitMeasures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            
        }

    }
}