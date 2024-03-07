using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RichillCapital.Domain;
using RichillCapital.SharedKernel.Specifications.Evaluators;

namespace RichillCapital.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddPersistenceOptions();

        services.AddMsSql();

        return services;
    }

    private static IServiceCollection AddPersistenceOptions(this IServiceCollection services)
    {
        services
            .AddOptions<PersistenceOptions>()
            .BindConfiguration(nameof(PersistenceOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }

    private static IServiceCollection AddMsSql(this IServiceCollection services)
    {
        services.AddDbContext<MsSqlEfCoreDbContext>((servicesProvider, options) =>
        {
            var dbOptions = servicesProvider
                .GetRequiredService<IOptions<PersistenceOptions>>()
                .Value.MsSqlOptions;

            options.UseSqlServer(dbOptions.ConnectionString);
        });

        services.AddScoped(typeof(IRepository<>), typeof(MsSqlEfCoreRepository<>));
        services.AddScoped(typeof(IReadOnlyRepository<>), typeof(MsSqlEfCoreRepository<>));

        services.AddScoped<IUnitOfWork>(serviceProvider =>
                serviceProvider.GetRequiredService<MsSqlEfCoreDbContext>());

        services.AddScoped<IInMemorySpecificationEvaluator, InMemorySpecificationEvaluator>();
        return services;
    }

}
