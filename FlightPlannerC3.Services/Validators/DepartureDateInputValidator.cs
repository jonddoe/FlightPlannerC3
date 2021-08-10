using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Core.Services;

namespace FlightPlannerC3.Services.Validators
{
    public class DepartureDateInputValidator : IInputValidator
    {
        public bool Validate(AddFlightRequest request)
        {
            return !string.IsNullOrEmpty(request.DepartureTime);
        }

        public bool Validate(SearchFlightsRequest request)
        {
            return !string.IsNullOrEmpty(request.DepartureDate);
        }
    }
}