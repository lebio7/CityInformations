using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    public class NewsDateConfiguration : IEntityTypeConfiguration<NewsDate>
    {
        public void Configure(EntityTypeBuilder<NewsDate> entity)
        {
            entity.ToTable("NEWSDATE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName(nameof(NewsDate.Id).ToUpper());

            entity.Property(e => e.NewsId)
                .HasColumnName(nameof(NewsDate.NewsId).ToUpper());

            entity.Property(e => e.TypeDateId)
                .HasColumnName(nameof(NewsDate.TypeDateId).ToUpper());

            entity.Property(e => e.Value)
                .IsUnicode(false)
                .HasColumnName(nameof(NewsDate.Value).ToUpper());
        }
    }
}
