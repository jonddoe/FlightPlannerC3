using System.Linq;
using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Core.Services;
using FlightPlannerC3.Data;

namespace FlightPlannerC3.Services.Validators
{
    public class IsNotInStorageValidator : IIsNotInStorageValidator
    {
        private readonly FlightPlannerDbContext _context;

        public IsNotInStorageValidator(FlightPlannerDbContext context)
        {
            _context = context;
        }

        public bool Validate(AddFlightRequest request)
        {
            var k = _context.Flights.FirstOrDefault(
                f => f.ArrivalTime == request.ArrivalTime &&
                     f.DepartureTime == request.DepartureTime &&
                     f.Carrier.ToLower().Trim() == request.Carrier.ToLower().Trim() &&
                     f.From.AirportName.ToLower().Trim() == request.From.AirportName.ToLower().Trim());

            return k == null;
        }
    }
}