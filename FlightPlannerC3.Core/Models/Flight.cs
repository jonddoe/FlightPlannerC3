using System.ComponentModel.DataAnnotations;

namespace FlightPlannerC3.Core.Models
{
    public class Flight : Entity
    {
        [Required]
        public Airport From { get; set; }
        [Required]
        public Airport To { get; set; }
        [MaxLength(20)] public string Carrier { get; set; }
        [MaxLength(30)] public string DepartureTime { get; set; }
        [MaxLength(30)] public string ArrivalTime { get; set; }
    }
}