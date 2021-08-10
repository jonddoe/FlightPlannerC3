using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Core.Services;

namespace FlightPlannerC3.Services.Validators
{
    public class AirportToInputValidator : AirportValidator, IInputValidator
    {
        public bool Validate(AddFlightRequest request)
        {
            return Validate(request.To);
        }

        public bool Validate(SearchFlightsRequest request)
        {
            return request.To != null;
        }
    }
}