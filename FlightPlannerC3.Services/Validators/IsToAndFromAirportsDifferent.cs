using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Core.Services;

namespace FlightPlannerC3.Services.Validators
{
    public class IsToAndFromAirportsDifferent : IInputValidator
    {
        public bool Validate(AddFlightRequest request)
        {
            return request.From != request.To;
            
        }

        public bool Validate(SearchFlightsRequest request)
        {
            return request.From != request.To;
        }
    }
}