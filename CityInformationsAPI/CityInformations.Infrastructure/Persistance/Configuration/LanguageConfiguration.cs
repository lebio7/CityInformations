using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> entity)
        {
            entity.ToTable("LANGUAGE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName(nameof(Language.Id).ToUpper());

            entity.Property(e => e.Culture)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName(nameof(Language.Culture).ToUpper());

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName(nameof(Language.Name).ToUpper());
        }
    }
}
