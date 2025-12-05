using Talky.Common.Data;
using Talky.Common.Data.Config;

namespace Talky.Common.Api;

public static class ApiDefaultsBootstrap
{
    public static void AddApiDefaults(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
        services.AddCommonData();
        
        services.AddCors();
        services.AddMemoryCache();
        services.AddHttpClient();
        
        services.AddControllers();
    }

    public static void UseApiDefaults(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        //app.UseSwagger();
        //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", env.ApplicationName));
        
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}