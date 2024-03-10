using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RichillCapital.Domain;
using RichillCapital.SharedKernel.Specifications.Evaluators;

namespace RichillCapital.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddSpecification();

        services.AddMsSql();
        services.AddDomainEventDispatcher();

        return services;
    }

    private static IServiceCollection AddMsSql(this IServiceCollection services)
    {
        services.AddDbContext<MsSqlEfCoreDbContext>((serviceProvider, options) =>
        {
            options.UseSqlServer("Server=127.0.0.1,1433;Database=richillcapital;User Id=SA;Password=Pa55w0rd!;TrustServerCertificate=true;", options =>
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

    private static IServiceCollection AddDomainEventDispatcher(this IServiceCollection services)
    {
        services.AddScoped<IDomainEventDispatcher, MediatorDomainEventDispatcher>();

        return services;
    }

    private static IServiceCollection AddSpecification(this IServiceCollection services)
    {
        services.AddScoped<IInMemorySpecificationEvaluator, InMemorySpecificationEvaluator>();

        return services;
    }
}