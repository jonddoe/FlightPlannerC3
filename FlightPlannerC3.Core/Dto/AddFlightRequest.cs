using FlightPlannerC3.Core.Models;

namespace FlightPlannerC3.Core.Dto
{
    public class AddFlightRequest
    {
        public Airport From { get; set; }
        public Airport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

       
    }
}