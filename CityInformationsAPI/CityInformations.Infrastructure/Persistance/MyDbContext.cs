﻿using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Domain.Entities;
using CityInformations.Infrastructure.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CityInformations.Infrastructure.Persistance
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Date> Dates { get; set; }
        public DbSet<TypeDate> TypeDates { get; set; }
        public DbSet<Descr> Descrs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationDate> LocationDates { get; set; }
        public DbSet<News> NewsItems { get; set; }
        public DbSet<NewsDate> NewsDates { get; set; }
        public DbSet<ObjectLocation> ObjectLocations { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Weather> Weathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DateConfiguration());
            modelBuilder.ApplyConfiguration(new DescrConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new LocationDateConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new NewsDateConfiguration());
            modelBuilder.ApplyConfiguration(new ObjectLocationConfiguration());
            modelBuilder.ApplyConfiguration(new TypeDateConfiguration());
            modelBuilder.ApplyConfiguration(new WeatherConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
