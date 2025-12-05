using Talky.Auth.Data;
using Talky.Auth.Service;
using Talky.Common.Data;
using Talky.Common.Api;

namespace Talky.Auth.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApiDefaults(Configuration);
        
        services.AddAuthData();
        services.AddAuthServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseApiDefaults(env);
    }
}