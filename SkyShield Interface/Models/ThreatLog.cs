
using Newtonsoft.Json;

namespace SkyShield_Interface.Models
{
    public class ThreatLog
    {
        [JsonProperty("time")]
        public string Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }

}
