using System;
using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Core.Services;

namespace FlightPlannerC3.Services.Validators
{
    public class DatesIntervalInputValidator : IInputValidator
    {
        public bool Validate(AddFlightRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Carrier) ||
                string.IsNullOrEmpty(request.DepartureTime) ||
                string.IsNullOrEmpty(request.ArrivalTime) ||
                request.To == null ||
                request.From == null ||
                string.IsNullOrEmpty(request.To?.AirportName) ||
                string.IsNullOrEmpty(request.To?.City) ||
                string.IsNullOrEmpty(request.To?.Country) ||
                string.IsNullOrEmpty(request.From?.AirportName) ||
                string.IsNullOrEmpty(request.From?.City) ||
                string.IsNullOrEmpty(request.From?.Country))
            {
                return false;
            }

            return !(DateTime.Parse(request.ArrivalTime) <= DateTime.Parse(request.DepartureTime));
        }

        public bool Validate(SearchFlightsRequest request)
        {
            return true;
        }
    }
}