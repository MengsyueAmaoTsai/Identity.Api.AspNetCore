
using RichillCapital.Identity.Api;

var app = WebApplication
    .CreateBuilder(args)
    .ConfigureServices()
    .Build();

await (await app.ConfigurePipelinesAsync())
    .RunAsync();

public partial class Program;