﻿using System.Threading.Tasks;
using FlightPlannerC3.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightPlannerC3.Data
{
    public class FlightPlannerDbContext : DbContext, IFlightPlannerDbContext
    {
        public FlightPlannerDbContext(DbContextOptions options) : base(options)
        {

        }

       

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        /*public EntityEntry<T> Entry<T>(T entity) where T : Entity
        {
            throw new System.NotImplementedException();
        }*/

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }

    }
}