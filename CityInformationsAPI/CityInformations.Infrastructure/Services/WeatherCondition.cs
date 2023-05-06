using AutoMapper;
using CityInformations.Application.Helpers;
using CityInformations.Application.Helpers.Configurations;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Application.Helpers.Responses;
using CityInformations.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CityInformations.Infrastructure.Services
{
    public class WeatherCondition : IWeatherCondition
    {
        private readonly HttpClient httpClient;
        private readonly WeatherAppSettings settings;
        private readonly IMyDbContext myDbContext;
        private readonly IMapper mapper;
        private readonly IDateTimeService dateTimeService;

        public WeatherCondition(HttpClient httpClient,
            IConfiguration configuration,
            IMapper mapper,
            IMyDbContext myDbContext,
            IDateTimeService dateTimeService)
        {
            this.httpClient = httpClient;
            settings = configuration.GetSection("WeatherApp")?.Get<WeatherAppSettings>();
            this.mapper = mapper;
            this.myDbContext = myDbContext;
            this.dateTimeService = dateTimeService;
        }

        public async Task<bool> Create(OpenWeatherMapResponse entity)
        {
            if (entity == null) return false;

            var newWeather = mapper.Map<Weather>(entity);
            newWeather.Id = 0;
            newWeather.AddedDate = dateTimeService.Current;

            myDbContext.Weathers.Add(newWeather);

            await myDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<OpenWeatherMapResponse> Get()
        {
            if (settings == null) return null;

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.MediaTypeJson));

            string url = BuildUrl();

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<OpenWeatherMapResponse>(json);

                return result;
            }

            return null;
        }

        private string BuildUrl() => $"{settings.Url}APPID={settings.ApiKey}&lat={settings.LAT}&lon={settings.LON}&units={settings.Units}";

    }
}
