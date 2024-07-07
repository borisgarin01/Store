using Dapper;
using Models;
using Npgsql;
using Repositories.Interfaces.Derived;

namespace Repositories.Concrete;

public class ManufacturersRepository : IManufacturersRepository
{
    public string ConnectionString { get; }

    public ManufacturersRepository(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public async Task<IEnumerable<Manufacturer>> GetAll()
    {
        IEnumerable<Manufacturer> manufacturers;
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            manufacturers = await connection.QueryAsync<Manufacturer>("SELECT * FROM Manufacturers");
        }
        return manufacturers;
    }

    public async Task AddAsync(Manufacturer manufacturer)
    {
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            await connection.ExecuteAsync("INSERT INTO Manufacturers(Name) VALUES (@Name);", new
            {
                manufacturer.Name
            });
        }
    }
}
