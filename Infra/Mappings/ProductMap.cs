using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);
            
            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            
            builder
                .Property(p => p.Description)
                .IsRequired();
            
            builder
                .HasOne(p => p.Category)
                .WithMany();
            
            builder
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("now()");

            builder
                .HasMany(p => p.Datasheets);
        }
    }
}