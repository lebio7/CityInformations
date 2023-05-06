using CityInformations.Application.Helpers.Interfaces;

namespace CityInformations.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Current { get => DateTime.Now; }
    }
}
