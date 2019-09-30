namespace Contacts.Core.Data.Model
{
    public interface IRepository<T, TContext>
    {
        T Add(T entity);
    }
}
