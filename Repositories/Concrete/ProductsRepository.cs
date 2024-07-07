using Dapper;
using Models;
using Npgsql;
using Repositories.Interfaces.Derived;

namespace Repositories.Concrete;

public class ProductsRepository : IProductsRepository
{
    public string ConnectionString { get; }

    public ProductsRepository(string connectionString)
    {
        ConnectionString = connectionString;
    }


    public async Task<IEnumerable<Product>> GetAll()
    {
        IEnumerable<Product> products;
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            products = await connection.QueryAsync<Product>("SELECT * FROM Products");
        }
        return products;
    }

    public async Task AddAsync(Product product)
    {
        using (var connection = new NpgsqlConnection(ConnectionString))
        {
            await connection.ExecuteAsync(@"
            INSERT INTO Products(
            Name, Description, CreatedAt, UpdatedAt, IsDeleted, DeletedAt, CategoryId, ManufacturerId) 
                VALUES 
            (@Name, @Description, @CreatedAt, @UpdatedAt, @IsDeleted, @DeletedAt, @CategoryId,@ManufacturerId);", new
            {
                product.Name,
                product.Description,
                product.CreatedAt,
                product.UpdatedAt,
                product.IsDeleted,
                product.DeletedAt,
                product.CategoryId,
                product.ManufacturerId
            });
        }
    }
}
