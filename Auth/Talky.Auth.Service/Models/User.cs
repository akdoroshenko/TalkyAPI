using Talky.Auth.Data.Entities;

namespace Talky.Auth.Service.Models;

public class User(UserEntity entity)
{
    public int Id { get; set; } = entity.Id;

    public string FirstName { get; set; } = entity.FirstName;

    public string LastName { get; set; } = entity.LastName;

    public string Email { get; set; } = entity.Email;

    public string FullName => $"{FirstName} {LastName}";
}