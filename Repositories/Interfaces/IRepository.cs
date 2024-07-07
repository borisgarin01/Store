namespace Repositories.Abstract;

public interface IRepository<T>
{
    string ConnectionString { get; }

    Task<IEnumerable<T>> GetAll();
    Task AddAsync(T item);
}
