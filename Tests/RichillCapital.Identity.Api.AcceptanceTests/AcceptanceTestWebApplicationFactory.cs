using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using RichillCapital.Persistence;

using Testcontainers.MsSql;

namespace RichillCapital.Identity.Api.AcceptanceTests;

public sealed class AcceptanceTestsWebApplicationFactory :
    WebApplicationFactory<Program>,
    IAsyncLifetime
{
    private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .WithEnvironment("ACCEPT_EULA", "Y")
        .WithEnvironment("SA_PASSWORD", "Pa55w0rd!")
        .WithPassword("Pa55w0rd!")
        .Build();

    public Task InitializeAsync() => _dbContainer.StartAsync();

    public new Task DisposeAsync() => _dbContainer.StopAsync();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services
                .SingleOrDefault(descriptor =>
                    descriptor.ServiceType == typeof(DbContextOptions<MsSqlEfCoreDbContext>));

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<MsSqlEfCoreDbContext>(options =>
            {
                options.UseSqlServer(_dbContainer.GetConnectionString(), options =>
                {
                    options.EnableRetryOnFailure(3);
                    options.CommandTimeout(30);
                });
            });

            services.PopulateSeeds();
        });
    }
}
