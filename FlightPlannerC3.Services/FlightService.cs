using System.Linq;
using System.Threading.Tasks;
using FlightPlannerC3.Core.Models;
using FlightPlannerC3.Core.Services;
using FlightPlannerC3.Data;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace FlightPlannerC3.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        private readonly FlightPlannerDbContext _context;


        public FlightService(FlightPlannerDbContext context) : base(context)
        {
            _context = context;
            _context.Set<Flight>();
        }

        public async Task<Flight> GetFullFlight(int id)
        {
            var flight = _context.Flights
                .Include(f => f.From)
                .Include(f => f.To).FirstOrDefault(x => x.Id == id);

            return flight;
        }

        public async Task DeleteFlightById(int id)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.Id == id);
            if (flight != null) _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlights()
        {
            _context.Flights.RemoveRange(_context.Flights);
            _context.Airports.RemoveRange(_context.Airports);
            await _context.SaveChangesAsync();
        }
    }
}