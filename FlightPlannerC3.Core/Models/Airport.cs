using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightPlannerC3.Core.Models
{
    public class Airport : Entity
    {
        [Required, MaxLength(20)]
        public string Country { get; set; }

        [Required, MaxLength(20)]
        public string City { get; set; }

        [JsonPropertyName("airport"), Required, MaxLength(3), Column(TypeName = "varchar(3)")]
        public string AirportName { get; set; }
    }
}