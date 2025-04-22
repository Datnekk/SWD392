using Scalar.AspNetCore;

namespace be.Extensions;

public static class ScalarExtensions
{
    public static IEndpointRouteBuilder AddScalarServices(this IEndpointRouteBuilder endpoint, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment()){
            endpoint.MapScalarApiReference(options => 
            {
                options.Title = "SWD392";
                options.Theme = ScalarTheme.BluePlanet;
                options.DefaultHttpClient = new (ScalarTarget.CSharp, ScalarClient.HttpClient);
                options.CustomCss = "";
                options.ShowSidebar = true;
            });
        }

        return endpoint;
    }
}