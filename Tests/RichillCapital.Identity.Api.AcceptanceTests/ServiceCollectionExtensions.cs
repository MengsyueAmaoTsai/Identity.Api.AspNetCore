using Microsoft.Extensions.DependencyInjection;
using RichillCapital.Persistence;

namespace RichillCapital.Identity.Api.AcceptanceTests;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection PopulateSeeds(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();

        var scopedServices = scope.ServiceProvider;

        var context = scopedServices.GetRequiredService<MsSqlEfCoreDbContext>();

        context.Database.EnsureCreated();

        Seed.Populate(scopedServices);

        return services;
    }
}
