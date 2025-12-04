using System.ComponentModel.DataAnnotations;

namespace Talky.Auth.Api.Models;

public class SignIn
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}

public record AccessTokenRequest([Required] string RefreshToken);

public record AccessTokenResponse(string Token, DateTimeOffset Expires);