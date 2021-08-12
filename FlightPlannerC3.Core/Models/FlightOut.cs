using System.Text.Json.Serialization;

namespace FlightPlannerC3.Core.Models
{
    public class FlightOut
    {
        public AirportOut From { get; set; }
        public AirportOut To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

        public int Id { get; set; }
    }
}