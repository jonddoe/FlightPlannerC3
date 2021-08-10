using System.Collections.Generic;
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
        //need this?
       private readonly DbSet<Airport> _db;

        public AirportService(FlightPlannerDbContext context, DbContextOptions airportService) : base(context)
        {
            _context = context;
            _airportService = airportService;
            _db = _context.Set<Airport>();
        }
        public async Task<Airport> GetAirport(int id)
        {
            await using var ctx = new FlightPlannerDbContext(_airportService);
            var srv = new AirportService(ctx, _airportService);

            var aa = srv.GetAirport(id);
          //  var aa = _context.Airports.FirstOrDefault(a => a.Id == id);
          //var a = srv.GetAirport(id);
            return await aa;
        }

        public Task DeleteAirportById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAirports()
        {
            throw new System.NotImplementedException();
        }

        
    }
}