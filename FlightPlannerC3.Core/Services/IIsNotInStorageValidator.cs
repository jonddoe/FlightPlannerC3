using FlightPlannerC3.Core.Dto;

namespace FlightPlannerC3.Core.Services
{
    public interface IIsNotInStorageValidator
    {
        bool Validate(AddFlightRequest request);
    }
}