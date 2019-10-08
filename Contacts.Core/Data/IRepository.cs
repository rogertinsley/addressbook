using System;
using System.Linq;

namespace Contacts.Core.Data
{
    public interface IRepository<T, TContext> : IDisposable
    {
        void Add(T entity);
        IQueryable<T> GetAsQueryable();
        void EnsureCreated();
        void EnsureDeleted();
        int Count();
    }
}
