using CityInformations.Application.Helpers;
using CityInformations.Application.Helpers.Configurations;
using CityInformations.Application.Helpers.Interfaces;
using CityInformations.Application.Helpers.Responses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CityInformations.Infrastructure.Services
{
    public class WeatherCondition : IWeatherCondition
    {
        private readonly HttpClient httpClient;
        private readonly WeatherAppSettings settings;

        public WeatherCondition(HttpClient httpClient,
            IConfiguration configuration)
        {
            this.httpClient = httpClient;
            settings = configuration.GetSection("WeatherApp")?.Get<WeatherAppSettings>();
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
