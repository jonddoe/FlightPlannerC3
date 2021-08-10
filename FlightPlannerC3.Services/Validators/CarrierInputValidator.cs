using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Core.Services;

namespace FlightPlannerC3.Services.Validators
{
    public class CarrierInputValidator: IInputValidator
    {
        public bool Validate(AddFlightRequest request)
        {
            return !string.IsNullOrEmpty(request.Carrier);
        }

        public bool Validate(SearchFlightsRequest request)
        {
            return true;
        }
    }
}