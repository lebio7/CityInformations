using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CityInformations.Application.Helpers.Responses.WeatherApi
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; }

        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }
    }
}
