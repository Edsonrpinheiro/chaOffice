using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class UnitMeansureMap : IEntityTypeConfiguration<UnitMeansure>
    {
        public void Configure(EntityTypeBuilder<UnitMeansure> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Name)
                .IsRequired();
            
            builder
                .Property(u => u.Acronym)
                .IsRequired();
        }
    }
}