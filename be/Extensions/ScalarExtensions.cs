using Scalar.AspNetCore;

namespace be.Extensions;

public static class ScalarExtensions
{
    public static IEndpointRouteBuilder AddScalarServices(this IEndpointRouteBuilder endpoint, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment()){
            endpoint.MapScalarApiReference(options => 
            {
                options.WithTitle("SWD392");
                options.WithTheme(ScalarTheme.BluePlanet);
                options.WithSidebar(false);	
            });
        }

        return endpoint;
    }
}