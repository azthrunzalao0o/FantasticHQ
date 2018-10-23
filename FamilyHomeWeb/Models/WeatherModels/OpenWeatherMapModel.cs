using Newtonsoft.Json;

namespace FamilyHomeWeb.Models.WeatherModels
{
    public class OpenWeatherMapModel
    {
        [JsonProperty(PropertyName = "weather")]
        public WeatherStatusInfo[] StatusInfo { get; set; }
        [JsonProperty(PropertyName = "main")]
        public WeatherMainInfo MainInfo { get; set; }
        public bool HasAPIError { get; set; } = false;
        public string ErrorMessage { get; set; }
    }
}