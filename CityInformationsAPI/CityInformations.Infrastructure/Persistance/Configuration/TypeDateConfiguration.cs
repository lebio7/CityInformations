using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    public class TypeDateConfiguration : IEntityTypeConfiguration<TypeDate>
    {
        public void Configure(EntityTypeBuilder<TypeDate> entity)
        {
            entity.ToTable("TYPEDATE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName(nameof(TypeDate.Id).ToUpper());

            entity.Property(e => e.IdDescr)
                .HasColumnName(nameof(TypeDate.IdDescr).ToUpper());

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName(nameof(TypeDate.Name).ToUpper());
        }
    }
}
