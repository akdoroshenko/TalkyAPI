using Microsoft.Extensions.DependencyInjection;
using Talky.Auth.Service.Services;

namespace Talky.Auth.Service;

public static class Bootstrap
{
    public static void AddAuthServices(this IServiceCollection services)
    {
        services.AddTransient<AuthService>();
    }
}