using Domain.Entities;
using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class DatasheetMap : IEntityTypeConfiguration<Datasheet>
    {
        public void Configure(EntityTypeBuilder<Datasheet> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            builder
                .Property(d => d.Labor)
                .IsRequired();
            
            builder
                .Property(d => d.Status)
                .HasDefaultValue(EDatasheetStatus.Created);

            builder
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("now()");

            builder
                .HasMany(d => d.Items);
        }
    }
}