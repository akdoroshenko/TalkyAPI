using Dapper;
using Microsoft.Data.SqlClient;
using Talky.Auth.Data.Entities;
using Talky.Auth.Data.Quieries;
using Talky.Common.Core.Results;
using Talky.Common.Data;

namespace Talky.Auth.Data;

public class AuthRepository(DbContext dbContext)
{
    public async Task<Result<UserEntity>> GetUserByCredentials(string email, string password)
    {
        try
        {
            var user = await dbContext.Connection.QueryFirstOrDefaultAsync<UserEntity>(
                AuthQueries.GetUserByCredentials,
                new { Email = email, Password = password });
            
            return user != null ? user : new Error("Invalid credentials");
        }
        catch (SqlException e) when (e.Number == 50002)
        {
            return new Error("Multiple users found with the same email");
        }
    }
    
    
    public async Task<Result<UserEntity>> GetUserById(int id)
    {
        var user = await dbContext.Connection.QueryFirstOrDefaultAsync<UserEntity>(
            AuthQueries.GetUserById,
            new { Id = id });
        
        return user != null ? user : new Error("No user with such id");
    }
}