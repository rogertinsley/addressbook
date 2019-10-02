namespace Contacts.Core.Data
{
    public interface IRepository<T, TContext>
    {
        T Add(T entity);
    }
}
