using System.ComponentModel.DataAnnotations;

namespace FlightPlannerC3.Core.Models
{
    public class Flight : Entity
    {
        [Required] public Airport From { get; set; }
        [Required] public Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}