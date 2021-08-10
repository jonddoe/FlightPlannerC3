using FlightPlannerC3.Core.Dto;

namespace FlightPlannerC3.Core.Services
{
    public interface IInputValidator
    {
        bool Validate(AddFlightRequest request);
        bool Validate(SearchFlightsRequest request);
    }
}