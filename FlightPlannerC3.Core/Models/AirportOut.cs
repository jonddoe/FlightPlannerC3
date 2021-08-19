using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightPlannerC3.Core.Models
{
    public class AirportOut
    {
        [Required] public string Country { get; set; }

        [Required] public string City { get; set; }

        [JsonPropertyName("airport"), Required]
        public string AirportName { get; set; }
    }
}