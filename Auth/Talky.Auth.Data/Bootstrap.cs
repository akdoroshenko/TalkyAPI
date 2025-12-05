using Microsoft.Extensions.DependencyInjection;

namespace Talky.Auth.Data;

public static class Bootstrap
{
    public static void AddAuthData(this IServiceCollection services)
    {
        services.AddTransient<AuthRepository>();
    }
}