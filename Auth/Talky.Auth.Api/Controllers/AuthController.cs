using Microsoft.AspNetCore.Mvc;
using Talky.Auth.Service.Services;
using Talky.Common.Core.Extensions;
using Talky.Common.Core.Results;

namespace Talky.Auth.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{
    [Route("test")]
    public async Task<IActionResult> Test([FromServices] AuthService service)
    {
        var (user, error) = await service.GetUser(1).Unwrap();
        
        user.ToConsole();
        user.ToConsole("User");
        error.ToConsole();
        
        return View();
    }
    
    [Route("signIn")]
    public IActionResult SignIn()
    {
        return View();
    }
}