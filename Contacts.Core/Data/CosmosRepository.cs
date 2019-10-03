using System.Linq;
using Contacts.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Core.Data
{
    public class CosmosRepository<T, TContext> : IRepository<T, TContext> where T : Entity where TContext : DbContext
    {
        protected readonly TContext Context;

        public CosmosRepository(TContext context)
        {
            this.Context = context;
        }

        public void Add(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public IQueryable<T> GetAsQueryable()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public void EnsureCreated()
        {
            Context.Database.EnsureCreated();
        }

        public void EnsureDeleted()
        {
            Context.Database.EnsureDeleted();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}