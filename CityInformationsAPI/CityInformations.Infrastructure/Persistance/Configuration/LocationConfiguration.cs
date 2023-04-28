using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    internal class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> entity)
        {
            entity.ToTable("LOCATION");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName(nameof(Location.Id).ToUpper());

            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName(nameof(Location.Address).ToUpper());

            entity.Property(e => e.Name)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.Property(e => e.ObjectLocationId)
                .HasColumnName(nameof(Location.ObjectLocationId).ToUpper());

            entity.HasOne(o => o.ObjectLocation)
              .WithMany()
              .HasForeignKey(o => o.ObjectLocationId);
        }
    }
}
