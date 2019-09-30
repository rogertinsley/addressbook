using Microsoft.EntityFrameworkCore;

namespace Contacts.Core.Data.Model
{
    public class CosmosRepository<T, TContext> : IRepository<T, TContext> where T : class where TContext : DbContext
    {
        protected readonly TContext _context;
        private DbSet<T> db;

        public CosmosRepository(TContext context)
        {
            _context = context;
            db = context.Set<T>();
        }

        public T Add(T entity)
        {
            var result = db.Add(entity);
            _context.SaveChanges();

            return result.Entity;
        }
    }
}