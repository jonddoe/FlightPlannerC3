using System.Linq;
using System.Threading.Tasks;
using FlightPlannerC3.Data;
using FlightPlannerC3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightPlannerC3.Controllers
{
    public class TestingApiController : ControllerBase
    {
        private readonly DbContextOptions _flightService;

        public TestingApiController(DbContextOptions flightService)
        {
            _flightService = flightService;
        }

        [Route("testing-api/clear"), HttpPost]
        public async Task<IActionResult> Clear()
        {
            await using var ctx = new FlightPlannerDbContext(_flightService);
            var srv = new FlightService(ctx);

            var airports = from f in ctx.Airports
                select f;

            foreach (var airport in airports)
            {
                ctx.Airports.Remove(airport);
            }

            var flights = from f in ctx.Flights
                select f;

            foreach (var flight in flights)
            {
                ctx.Flights.Remove(flight);
            }

            await srv.DeleteFlights();

            return Ok();
        }
    }
}