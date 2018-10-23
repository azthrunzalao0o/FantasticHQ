using Newtonsoft.Json;

namespace FamilyHomeWeb.Models.WeatherModels
{
    public class WeatherMainInfo
    {
        [JsonProperty(PropertyName = "temp")]
        public double Temperature { get; set; }
        [JsonProperty(PropertyName = "temp_min")]
        public double LowestTemperature { get; set; }
        [JsonProperty(PropertyName = "temp_max")]
        public double HighestTemperature { get; set; }
    }
}