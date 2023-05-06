using CityInformations.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInformations.Application.Helpers.Interfaces
{
    public interface IMyDbContext
    {
        DbSet<Date> Dates { get; set; }
        DbSet<TypeDate> TypeDates { get; set; }
        DbSet<Descr> Descrs { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<LocationDate> LocationDates { get; set; }
        DbSet<NewsDate> NewsDates { get; set; }
        DbSet<ObjectLocation> ObjectLocations { get; set; }
        DbSet<News> News { get; set; }
        DbSet<Weather> Weathers { get; set; }
    }
}
