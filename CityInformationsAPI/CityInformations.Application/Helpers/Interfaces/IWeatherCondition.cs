using CityInformations.Application.Helpers.Responses;

namespace CityInformations.Application.Helpers.Interfaces
{
    public interface IWeatherCondition
    {
        public Task<OpenWeatherMapResponse> Get();

        public Task<bool> Create(OpenWeatherMapResponse entity);
    }
}
