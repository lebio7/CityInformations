using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    public class LocationDateConfiguration : IEntityTypeConfiguration<LocationDate>
    {
        public void Configure(EntityTypeBuilder<LocationDate> entity)
        {
            entity.ToTable("LOCATIONDATE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName(nameof(LocationDate.Id).ToUpper());

            entity.Property(e => e.LocationId)
                .HasColumnName(nameof(LocationDate.LocationId).ToUpper());

            entity.Property(e => e.TypeDateId)
                .HasColumnName(nameof(LocationDate.TypeDateId).ToUpper());

            entity.Property(e => e.Value)
                .IsUnicode(false)
                .HasColumnName(nameof(LocationDate.Value).ToUpper());
        }
    }
}
