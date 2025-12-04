using Talky.Auth.Data;
using Talky.Auth.Service.Models;
using Talky.Common.Core.Results;

namespace Talky.Auth.Service.Services;

public class AuthService(AuthRepository repository)
{
    public async Task<Result<User>> GetUser(int id)
    {
        //Refactor ??
        var (user, error) = await repository.GetUserById(id).Unwrap();
        if (error)
        {
            return error.Wrap();
        }

        return new User(user);
    }

    public async Task<Result<User>> GetUser(string email, string password)
    {
        var (user, error) = await repository.GetUserByCredentials(email, password).Unwrap();
        if (error)
        {
            return error.Wrap();
        }
        
        return new User(user);
    }
}