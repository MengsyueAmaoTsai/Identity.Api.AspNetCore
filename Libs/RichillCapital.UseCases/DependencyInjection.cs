using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddMediators();

        return services;
    }

    private static IServiceCollection AddMediators(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);
        });

        return services;
    }
}
