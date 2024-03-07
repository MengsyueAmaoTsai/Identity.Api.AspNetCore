using RichillCapital.UseCases;
using RichillCapital.Persistence;

namespace RichillCapital.Identity.Api;

public static class WebApplicationExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // builder.Host.UseSerilog((context, configuration) =>
        //     configuration.ReadFrom.Configuration(builder.Configuration));

        builder.Services.AddUseCases();
        builder.Services.AddPersistence();

        return builder;
    }

    public static async Task<WebApplication> ConfigurePipelinesAsync(this WebApplication app)
    {
        // app.UseSerilogRequestLogging();

        app.InitializeSeeds();

        app.UseCustomCorsPolicy();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.MapControllers();

        return await Task.FromResult(app);
    }

    private static WebApplication InitializeSeeds(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();

        try
        {
            var context = services.GetRequiredService<MsSqlEfCoreDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            SeedProvider.Populate(services);

            logger.LogInformation("Seed populated successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred seeding the database. {exceptionMessage}", ex.Message);
        }

        return app;
    }

    private static WebApplication UseCustomCorsPolicy(this WebApplication app)
    {
        app.UseCors("default");

        return app;
    }
}