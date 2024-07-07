using Dapper;
using Microsoft.AspNetCore.Identity;
using Models;
using Npgsql;
using System.Data;

namespace Repositories.Identity;

public sealed class DapperUserStore : IUserStore<User>
{
    private readonly string _connectionString;

    public DapperUserStore(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.ExecuteAsync(@"INSERT INTO AspNetUsers(Id, UserName, Email, PasswordHash) 
                VALUES(@Id, @UserName, @Email, @PasswordHash)", new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.PasswordHash
            });
        }
        return IdentityResult.Success;
    }

    public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
