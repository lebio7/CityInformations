using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.ToTable("EVENT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName(nameof(Event.Id).ToUpper());
            entity.Property(e => e.Name)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName(nameof(Event.Name).ToUpper());
        }
    }
}
