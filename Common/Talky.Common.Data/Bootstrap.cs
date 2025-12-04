using Microsoft.Extensions.DependencyInjection;

namespace Talky.Common.Data;

public static class Bootstrap
{
    public static void AddCommonData(this IServiceCollection services)
    {
        services.AddTransient<DbContext>();
    }
}