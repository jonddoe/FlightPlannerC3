using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly DbSet<Flight> _db;


        public FlightService(FlightPlannerDbContext context) : base(context)
        {
            _context = context;

            _db = _context.Set<Flight>();
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


        public async Task<IEnumerable<Flight>> GetFlights(Expression<Func<Flight, bool>> expression,
            List<string> includes = null)
        {
            IQueryable<Flight> query = _db;
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, p) => current.Include(p));
            }

            return await query.AsNoTracking().ToListAsync();
        }


        public async Task DeleteFlights()
        {
            _context.Flights.RemoveRange(_context.Flights);
            _context.Airports.RemoveRange(_context.Airports);

            await _context.SaveChangesAsync();
        }
    }
}