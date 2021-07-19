using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class IngredientMap : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .HasOne(d => d.UnitMeansure)
                .WithMany();
            
            builder
                .Property(d => d.TotalQuantity)
                .IsRequired();
            
            builder
                .Property(d => d.Price)
                .IsRequired();

            builder
                .Property(d => d.Name)
                .IsRequired();

            builder
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("now()");

            builder
                .Property(d => d.Status)
                .HasDefaultValue(1);
        }
    }
}