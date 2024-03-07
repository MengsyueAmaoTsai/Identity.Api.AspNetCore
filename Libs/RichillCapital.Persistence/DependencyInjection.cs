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

        services.AddSpecification();

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
        services.AddDbContext<MsSqlEfCoreDbContext>((serviceProvider, options) =>
        {
            var sqlServerOptions = serviceProvider
                .GetRequiredService<IOptions<PersistenceOptions>>().Value;

            options.UseSqlServer(sqlServerOptions.MsSqlOptions.ConnectionString, options =>
            {
                options.EnableRetryOnFailure(3);
                options.CommandTimeout(30);
            });

            options.EnableDetailedErrors(true);
            options.EnableSensitiveDataLogging(true);
        });

        services.AddRepository();
        services.AddUnitOfWork();

        return services;
    }

    private static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(MsSqlEfCoreRepository<>));
        services.AddScoped(typeof(IReadOnlyRepository<>), typeof(MsSqlEfCoreRepository<>));

        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork>(serviceProvider =>
                serviceProvider.GetRequiredService<MsSqlEfCoreDbContext>());

        return services;
    }

    private static IServiceCollection AddSpecification(this IServiceCollection services)
    {
        services.AddScoped<IInMemorySpecificationEvaluator, InMemorySpecificationEvaluator>();

        return services;
    }
}
