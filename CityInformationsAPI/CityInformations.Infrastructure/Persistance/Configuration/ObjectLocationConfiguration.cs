using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    public class ObjectLocationConfiguration : IEntityTypeConfiguration<ObjectLocation>
    {
        public void Configure(EntityTypeBuilder<ObjectLocation> entity)
        {
            entity.ToTable("OBJECTLOCATION");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName(nameof(ObjectLocation.Id).ToUpper());

            entity.Property(e => e.Name)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName(nameof(ObjectLocation.Name).ToUpper());
        }
    }
}
