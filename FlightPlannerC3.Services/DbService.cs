using System.Collections.Generic;
using System.Linq;
using FlightPlannerC3.Core.Models;
using FlightPlannerC3.Core.Services;
using FlightPlannerC3.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightPlannerC3.Services
{
    public class DbService : IDbService
    {
        protected readonly FlightPlannerDbContext Context;

        public DbService(FlightPlannerDbContext context)
        {
            Context = context;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return Context.Set<T>();
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return Context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return Context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public void Create<T>(T entity) where T : Entity
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            if (entity == null) return;
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }
    }
}