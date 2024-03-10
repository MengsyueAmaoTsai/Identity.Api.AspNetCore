using RichillCapital.Persistence;

namespace RichillCapital.Identity.Api;

public static class WebApplicationExtensions
{
    public static WebApplication PopulateSeed(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();

        try
        {
            var context = services.GetRequiredService<MsSqlEfCoreDbContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Seed.Populate(services);

            logger.LogInformation("Seed populated successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred seeding the database. {exceptionMessage}", ex.Message);
        }

        return app;
    }
}