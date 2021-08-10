using System.ComponentModel.DataAnnotations;

namespace FlightPlannerC3.Core.Dto
{
    public class SearchFlightsRequest
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string DepartureDate { get; set; }
    }
}