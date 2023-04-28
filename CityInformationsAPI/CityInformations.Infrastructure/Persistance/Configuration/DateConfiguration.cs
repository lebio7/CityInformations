using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    public class DateConfiguration : IEntityTypeConfiguration<Date>
    {
        public void Configure(EntityTypeBuilder<Date> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Date");

            entity.ToTable("DATE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName(nameof(Date.Id).ToUpper());
            entity.Property(e => e.TypeDateId).HasColumnName(nameof(Date.TypeDateId).ToUpper());

            entity.Property(e => e.Value)
                .IsUnicode(false)
                .HasColumnName(nameof(Date.Value).ToUpper());

            entity.HasOne(o => o.TypeDate)
            .WithMany()
            .HasForeignKey(o => o.TypeDateId);
        }
    }
}
