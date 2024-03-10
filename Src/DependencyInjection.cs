namespace RichillCapital.Identity.Api;

internal static class DependencyInjection
{
    internal static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();

        return services;
    }
}