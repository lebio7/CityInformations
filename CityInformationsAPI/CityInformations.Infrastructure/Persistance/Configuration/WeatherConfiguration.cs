using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    public class WeatherConfiguration : IEntityTypeConfiguration<Weather>
    {
        public void Configure(EntityTypeBuilder<Weather> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Weather");

            entity.ToTable("WEATHER");

            entity.Property(e => e.Id)
                .HasColumnName(nameof(Weather.Id).ToUpper());

            entity.Property(e => e.Temperature)
                .HasColumnName(nameof(Weather.Temperature).ToUpper());

            entity.Property(e => e.Pressure)
              .HasColumnName(nameof(Weather.Pressure).ToUpper());

            entity.Property(e => e.AddedDate)
                 .HasColumnName(nameof(Weather.AddedDate).ToUpper())
                 .HasColumnType("datetime");

            entity.Property(e => e.Icon)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName(nameof(Weather.Icon).ToUpper());
        }
    }
}
