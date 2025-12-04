namespace Talky.Auth.Data.Quieries;

public static class AuthQueries
{
    private const string BaseQuery = @"SELECT 
    u.Id,
    u.FirstName,
    u.LastName,
    a.Email,
    a.Role
FROM Users u INNER JOIN dbo.Accounts a on a.Id = u.AccountId
WHERE a.IsDeleted = 0";
    
    public const string GetUserByCredentials = BaseQuery + " AND a.Email = @Email AND a.Password = @Password";
    
    public const string GetUserById = BaseQuery + " AND u.Id = @Id";
}