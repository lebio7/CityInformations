using Newtonsoft.Json;

namespace CityInformations.Application.Helpers.Responses.WeatherApi
{
    public class Rain
    {
        [JsonProperty("1h")]
        public float OneHour { get; set; }
    }
}
