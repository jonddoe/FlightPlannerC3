using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightPlannerC3.Core.Models;
using FlightPlannerC3.Core.Services;
using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlannerC3.Controllers
{
    [Authorize]
    [ApiController, Route("admin-api/flights")]
    public class AdminApiController : ControllerBase
    {
        public AdminApiController(IFlightService flightService, IEnumerable<IInputValidator> validators,
            FlightPlannerDbContext context)
        {
            _flightService = flightService;
            _validators = validators;
            _context = context;
        }

        private readonly IFlightService _flightService;
        private readonly FlightPlannerDbContext _context;
        private readonly IEnumerable<IInputValidator> _validators;

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetFlights(int id)
        {
            var flight = await _flightService.GetFullFlight(id);

            if (flight != null)
            {
                return Ok(flight);
            }

            return NotFound();
        }

        [Route("")]
        [HttpPut]
        public IActionResult PutFlight(AddFlightRequest newFlight)
        {
            if (_validators.Any(v => v.Validate(newFlight) == false))
            {
                return BadRequest();
            }

            var k = _context.Flights.FirstOrDefault(
                f => f.ArrivalTime == newFlight.ArrivalTime &&
                     f.DepartureTime == newFlight.DepartureTime &&
                     f.Carrier.ToLower().Trim() == newFlight.Carrier.ToLower().Trim() &&
                     f.From.AirportName.ToLower().Trim() == newFlight.From.AirportName.ToLower().Trim());
            if (k != null)
            {
                return Conflict();
            }

            var flightToBeAdded = new Flight
            {
                ArrivalTime = newFlight.ArrivalTime,
                DepartureTime = newFlight.DepartureTime,
                Carrier = newFlight.Carrier,
                From = new Airport
                {
                    City = newFlight.From.City,
                    Country = newFlight.From.Country,
                    AirportName = newFlight.From.AirportName
                },
                To = new Airport
                {
                    City = newFlight.To.City,
                    Country = newFlight.To.Country,
                    AirportName = newFlight.To.AirportName
                }
            };

            if (_validators.All(v => v.Validate(newFlight)))
            {
                _flightService.Create(flightToBeAdded);
            }

            var flightWithNoId = new FlightOut
            {
                From = new AirportOut
                {
                    Country = flightToBeAdded.From.Country,
                    City = flightToBeAdded.From.City,
                    AirportName = flightToBeAdded.From.AirportName,
                },
                To = new AirportOut
                {
                    Country = flightToBeAdded.To.Country,
                    City = flightToBeAdded.To.City,
                    AirportName = flightToBeAdded.To.AirportName,
                },
                Carrier = flightToBeAdded.Carrier,
                DepartureTime = flightToBeAdded.DepartureTime,
                ArrivalTime = flightToBeAdded.ArrivalTime,
                Id = flightToBeAdded.Id
            };

            return Created(string.Empty, flightWithNoId);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await _flightService.DeleteFlightById(id);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}