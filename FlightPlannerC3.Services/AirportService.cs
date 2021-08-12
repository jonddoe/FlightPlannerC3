using System.Linq;
using System.Threading.Tasks;
using FlightPlannerC3.Core.Models;
using FlightPlannerC3.Core.Services;
using FlightPlannerC3.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightPlannerC3.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        private readonly FlightPlannerDbContext _context;
        private readonly DbContextOptions _airportService;


        public AirportService(FlightPlannerDbContext context, DbContextOptions airportService) : base(context)
        {
            _context = context;
            _airportService = airportService;
        }

        public async Task<Airport> GetAirport(int id)
        {
            await using var ctx = new FlightPlannerDbContext(_airportService);
            var srv = new AirportService(ctx, _airportService);

            var airport = srv.GetAirport(id);
            return await airport;
        }

        public async Task DeleteAirportById(int id)
        {
            var airport = _context.Airports.FirstOrDefault(f => f.Id == id);
            if (airport != null) _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAirports()
        {
            _context.Airports.RemoveRange(_context.Airports);
            await _context.SaveChangesAsync();
        }
    }
}