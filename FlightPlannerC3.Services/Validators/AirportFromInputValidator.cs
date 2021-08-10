using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Core.Services;

namespace FlightPlannerC3.Services.Validators
{
    public class AirportFromInputValidator : AirportValidator, IInputValidator
    {
        public bool Validate(AddFlightRequest request)
        {
            return Validate(request.From);
        }

        public bool Validate(SearchFlightsRequest request)
        {
            return request.From!=null;
        }

        /*private static bool Validate(string requestFrom)
        {
            while (true)
            {
            }
        }*/
    }
}