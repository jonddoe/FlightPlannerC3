using FlightPlannerC3.Core.Models;

namespace FlightPlannerC3.Services.Validators
{
    public class AirportValidator
    {
        protected bool Validate(Airport airport)
        {
            return !(
                string.IsNullOrEmpty(airport?.AirportName) &&
                string.IsNullOrEmpty(airport?.City) &&
                string.IsNullOrEmpty(airport?.Country));
        }
    }
}