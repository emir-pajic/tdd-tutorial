using Newtonsoft.Json;

namespace BHGovernment.FireDepartment.API.Model
{
    public class Sensor
    {
        [JsonProperty("SensorId")]
        public string SensorId { get; set; }

        [JsonProperty("SensorFriendlyName")]
        public string SensorFriendlyName { get; set; }

        [JsonProperty("SensorLocation")]
        public string SensorLocation { get; set; }

        [JsonProperty("Active")]
        public bool Active { get; set; }
    }
}
