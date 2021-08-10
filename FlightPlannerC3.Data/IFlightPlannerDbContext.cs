using System.Threading.Tasks;
using FlightPlannerC3.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FlightPlannerC3.Data
{
    public interface IFlightPlannerDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DatabaseFacade Database { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbSet<Flight> Flights { get; set; }
        DbSet<Airport> Airports { get; set; }
    }
}