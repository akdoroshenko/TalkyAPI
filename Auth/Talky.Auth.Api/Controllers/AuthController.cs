using Microsoft.AspNetCore.Mvc;

namespace Talky.Auth.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{
    [Route("signIn")]
    public IActionResult SignIn()
    {
        return View();
    }
}