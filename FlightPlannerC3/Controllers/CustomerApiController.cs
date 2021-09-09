using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightPlannerC3.Core.Dto;
using FlightPlannerC3.Core.Models;
using FlightPlannerC3.Core.Services;
using FlightPlannerC3.Data;
using FlightPlannerC3.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace FlightPlannerC3.Controllers
{
    [Route("api")]
    public class CustomerApiController : ControllerBase
    {
        public CustomerApiController(FlightPlannerDbContext context, IEnumerable<IInputValidator> validators,
            IFlightService flightService)
        {
            _context = context;
            _flightService = flightService;
            _validators = validators;
        }

        private static readonly object Locker = new object();
        private readonly FlightPlannerDbContext _context;
        private readonly IFlightService _flightService;
        private readonly IEnumerable<IInputValidator> _validators;

        [Route("airports")]
        [HttpGet]
        public async Task<IActionResult> SearchAirports(string search)
        {
            search = search.ToLower().Trim();
            var airportList = _context.Airports.ToList();
            var noIdAirportList = airportList.Select(a =>
                    new AirportOut
                    {
                        Country = a.Country,
                        City = a.City,
                        AirportName = a.AirportName
                    })
                .ToList();

            var airportsOut = noIdAirportList.Where(f =>
                f.AirportName.ToLower().Contains(search) ||
                f.City.ToLower().Contains(search) ||
                f.Country.ToLower().Contains(search)).ToList();

            return airportList.Count == 0 ? (IActionResult)NotFound() : Ok(airportsOut);
        }

        [Route("flights/{id:int}")]
        [HttpGet]
        public IActionResult GetFlightById(int id)
        {
            var s = _flightService.GetFullFlight(id);
            if (s.Result == null)
            {
                return NotFound();
            }

            var flightWithNoId = new FlightOut
            {
                From = new AirportOut
                {
                    Country = s.Result.From.Country,
                    City = s.Result.From.City,
                    AirportName = s.Result.From.AirportName
                },
                To = new AirportOut
                {
                    Country = s.Result.To.Country,
                    City = s.Result.To.City,
                    AirportName = s.Result.To.AirportName
                },
                Carrier = s.Result.Carrier,
                DepartureTime = s.Result.DepartureTime,
                ArrivalTime = s.Result.ArrivalTime,
                Id = s.Result.Id
            };
            return Ok(flightWithNoId);
        }

        [Route("flights/search")]
        [HttpPost]
        public IActionResult FindFlight([FromBody] SearchFlightsRequest request)
        {
            lock (Locker)
            {
                if (request == null || _validators.Any(v => v.Validate(request) == false))
                {
                    return BadRequest();
                }

                var flight = _context.Flights
                    .Include(f => f.From)
                    .Include(f => f.To).FirstOrDefault(f =>
                        f.DepartureTime.Substring(0, 10) == request.DepartureDate &&
                        f.From.AirportName == request.From &&
                        f.To.AirportName == request.To);
                var flightList = new List<Flight>();

                if (flight != null)
                {
                    flightList.Add(flight);
                }

                var page = new PageResult(flightList);
                return Ok(page);
            }
        }
    }
}