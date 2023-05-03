using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityInformations.Infrastructure.Persistance.Configuration
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> entity)
        {
            entity.ToTable("NEWS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName(nameof(News.Id).ToUpper());
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName(nameof(News.CreatedDate).ToUpper());

            entity.Property(e => e.EventId)
                .HasColumnName(nameof(News.EventId).ToUpper());

            entity.Property(e => e.Title)
                .IsUnicode(false)
                .HasColumnName(nameof(News.Title).ToUpper());

            entity.HasMany(x => x.NewsDates)
                .WithOne(x => x.News)
                .HasForeignKey(x => x.NewsId);
        }
    }
}
