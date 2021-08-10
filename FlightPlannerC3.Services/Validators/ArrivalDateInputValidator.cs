using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Core.Services;

namespace FlightPlannerC3.Services.Validators
{
    public class ArrivalDateInputValidator : IInputValidator
    {
        public bool Validate(AddFlightRequest request)
        {
            return !string.IsNullOrEmpty(request.ArrivalTime);
        }

        public bool Validate(SearchFlightsRequest request)
        {
            return !string.IsNullOrEmpty(request.DepartureDate);
        }
    }
}