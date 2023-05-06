using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Infrastructure.Persistance;
using CityInformations.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CityInformations.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IMyDbContext, MyDbContext>();
            services.AddScoped<IWeatherCondition, WeatherCondition>();

            services.AddTransient<HttpClient>();
            services.AddSingleton<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}
