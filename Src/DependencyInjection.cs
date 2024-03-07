using Microsoft.OpenApi.Models;

namespace RichillCapital.Identity.Api;

internal static class DependencyInjection
{
    internal static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddMiddlewares();
        services.AddEndpoints();
        services.AddOpenApiDocumentation();
        services.AddCustomCorsPolicy();

        return services;
    }

    private static IServiceCollection AddCustomCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy(
            "default",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

        return services;
    }


    private static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddProblemDetails();

        return services;
    }

    private static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services)
    {
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Exchange.Api", Version = "v1" });
                options.EnableAnnotations();
            });

        return services;
    }
}