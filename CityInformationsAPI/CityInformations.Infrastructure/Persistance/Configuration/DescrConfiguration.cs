using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    public class DescrConfiguration : IEntityTypeConfiguration<Descr>
    {
        public void Configure(EntityTypeBuilder<Descr> entity)
        {
            entity.ToTable("DESCR");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName(nameof(Descr.Id).ToUpper());
            entity.Property(e => e.Descrpiton)
                .IsUnicode(false)
                .HasColumnName(nameof(Descr.Descrpiton).ToUpper());
            entity.Property(e => e.LanguageId).HasColumnName(nameof(Descr.LanguageId).ToUpper());
            entity.Property(e => e.MainDescrId).HasColumnName(nameof(Descr.MainDescrId).ToUpper());


            entity.HasOne(o => o.Language)
            .WithMany()
            .HasForeignKey(o => o.LanguageId);
        }
    }
}
