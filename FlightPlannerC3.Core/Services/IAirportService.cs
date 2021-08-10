using System.Threading.Tasks;
using FlightPlannerC3.Core.Models;

namespace FlightPlannerC3.Core.Services
{
    public interface IAirportService : IEntityService<Airport>
    {
        Task<Airport> GetAirport(int id);
        Task DeleteAirportById(int id);
        Task DeleteAirports();
    }
}