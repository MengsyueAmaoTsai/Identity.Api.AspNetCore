using Microsoft.Extensions.DependencyInjection;

namespace RichillCapital.Persistence;

public static class Seeds
{
    public static void Populate(IServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<MsSqlEfCoreDbContext>();

        context.SaveChanges();
    }
}