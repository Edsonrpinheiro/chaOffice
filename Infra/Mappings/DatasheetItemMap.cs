using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class DatasheetItemMap : IEntityTypeConfiguration<DatasheetItem>
    {
        public void Configure(EntityTypeBuilder<DatasheetItem> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .HasOne(d => d.Ingredient)
                .WithMany();
            
            builder
                .Property(d => d.Quantity)
                .IsRequired();
            
            builder
                .Property(d => d.Price);

            builder
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("now()");
        }
    }
}