using Newtonsoft.Json;

namespace FamilyHomeWeb.Models.WeatherModels
{
    public class WeatherStatusInfo
    {
        [JsonProperty(PropertyName = "main")]
        public string WeatherStatus { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string WeatherDescription { get; set; }
        [JsonProperty(PropertyName = "icon")]
        public string WeatherIconID { get; set; }
    }
}