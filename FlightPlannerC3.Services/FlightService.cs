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
        //private readonly DbService _dbService;

        public FlightService(FlightPlannerDbContext context) : base(context)
        {
            _context = context;
            // _dbService = dbService;
            _db = _context.Set<Flight>();
        }

        public async Task<Flight> GetFullFlight(int id)
        {
            /*await using var ctx = new FlightPlannerDbContext(_flightService);
            var srv = new FlightService(ctx, _flightService, _airportService);

            var asrv = new AirportService(_context, _flightService);*/
            
            var flight =  _context.Flights
                .Include(f => f.From)
                .Include(f => f.To).FirstOrDefault(x => x.Id == id);
            /*var f = new FlightOut
            {
                From =
                {
                    AirportName = flight.From.AirportName,
                    City = flight.From.City,
                    Country = flight.From.Country
                },
                To = {AirportName = flight.To.AirportName,
                    City = flight.To.City,
                    Country = flight.To.Country},
                ArrivalTime = flight.ArrivalTime,
                DepartureTime = flight.DepartureTime,
                Carrier = flight.Carrier
            };*/

            return flight;
            }

       
        public async Task DeleteFlightById(int id)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.Id == id);
            if (flight != null) _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }

      

        

        //wat iz dis ?
        /*public async Task<Flight> Get(Expression<Func<Flight, bool>> expression, List<string> includes = null)
        {
            IQueryable<Flight> query = _db;
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, p) => current.Include(p));
            }
            
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);

          // return query.AsNoTracking().FirstOrDefaultAsync(expression);
        }*/

        public async Task<IEnumerable<Flight>> GetFlights(Expression<Func<Flight, bool>> expression, List<string> includes = null)
        {
            IQueryable<Flight> query = _db;
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, p) => current.Include(p));
            }

            return await query.AsNoTracking().ToListAsync();

           
            // return await Query().ToListAsync();
        }

       

        /*public async Task<ServiceResult> AddFlight(Flight flight)
        {
            
            if (await FlightExists(flight))
            {
                return new ServiceResult(false);
            }
        }*/


       // use dis?
        /*public void Update(Flight entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            
        }*/


        /*public async Task<ServiceResult> DeleteFlightById(int id)
        {
            var flight = await GetById(id);

        }*/
        /*public Task<bool> FlightExists(Flight flight)
        {
            return  Query().AnyAsync(f =>
                f.Carrier == flight.Carrier &&
                f.ArrivalTime == flight.ArrivalTime &&
                f.DepartureTime == flight.DepartureTime &&
                f.From.AirportName == flight.From.AirportName &&
                f.From.City == flight.From.City &&
                f.From.Country == flight.From.Country &&
                f.To.AirportName == flight.To.AirportName &&
                f.To.City == flight.To.City &&
                f.To.Country == flight.To.Country);
        }*/

        public async Task DeleteFlights()
        {
            _context.Flights.RemoveRange(_context.Flights);
            _context.Airports.RemoveRange(_context.Airports);

            await _context.SaveChangesAsync();

        }
    }
}