using RichillCapital.Persistence;
using RichillCapital.UseCases;

namespace RichillCapital.Identity.Api;

internal static class WebApplicationExtensions
{
    internal static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddUseCases();

        builder.Services.AddPersistence();

        builder.Services.AddWebApi();

        return builder;
    }

    internal static WebApplication ConfigurePipelines(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.PopulateSeed();
        }

        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.MapControllers();

        return app;
    }

    private static WebApplication PopulateSeed(this WebApplication app)
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