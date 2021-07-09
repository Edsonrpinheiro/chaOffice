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
                .WithOne()
                .HasForeignKey<Ingredient>(i => i.Id);
            
            builder
                .Property(d => d.Quantity)
                .IsRequired();
            
            builder
                .Property(d => d.Price)
                .IsRequired();

            builder
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("now()");
        }
    }
}