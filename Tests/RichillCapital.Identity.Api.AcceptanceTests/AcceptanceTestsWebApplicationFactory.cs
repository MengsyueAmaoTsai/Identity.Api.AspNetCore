using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace RichillCapital.Identity.Api.AcceptanceTests;

public sealed class AcceptanceTestsWebApplicationFactory : 
    WebApplicationFactory<Program>,
    IAsyncLifetime
{
    public Task InitializeAsync() => Task.CompletedTask;
    public new Task DisposeAsync() => Task.CompletedTask;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
    }
}