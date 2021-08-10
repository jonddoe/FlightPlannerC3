using System.Text.Json.Serialization;

namespace FlightPlannerC3.Core.Models
{
    public abstract class Entity
    {
       //[JsonIgnore]
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}