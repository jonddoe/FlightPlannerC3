using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Core.Services;

namespace FlightPlannerC3.Services.Validators
{
    public class AirportCodesInputValidator : IInputValidator
    {
        public bool Validate(AddFlightRequest request)
        {
            return request.From.AirportName.ToLower().Trim()
                   != request.To.AirportName.ToLower().Trim();
        }

        public bool Validate(SearchFlightsRequest request)
        {
            return request.From != request.To;
        }
    }
}