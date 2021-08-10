using System.Threading.Tasks;
using FlightPlannerC3.Core.Models;
using Task = System.Threading.Tasks.Task;

namespace FlightPlannerC3.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Task<Flight> GetFullFlight(int id);
        Task DeleteFlightById(int id);
        Task DeleteFlights();
    }
}