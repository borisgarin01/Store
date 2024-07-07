using Dapper;
using Models;
using Npgsql;
using Repositories.Interfaces.Derived;

namespace Repositories.Concrete;

public class CategoriesRepository : ICategoriesRepository
{
    public string ConnectionString { get; }

    public CategoriesRepository(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        IEnumerable<Category> categories;
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            categories = await connection.QueryAsync<Category>("SELECT * FROM Categories");
        }
        return categories;
    }

    public async Task AddAsync(Category category)
    {
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            await connection.ExecuteAsync("INSERT INTO Categories(Name) VALUES (@Name);", new
            {
                category.Name
            });
        }
    }
}
