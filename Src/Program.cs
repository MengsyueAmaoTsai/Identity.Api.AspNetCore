using RichillCapital.Identity.Api;

var app = WebApplication
    .CreateBuilder(args)
    .ConfigureServices()
    .Build();

await app
    .ConfigurePipelines()
    .RunAsync();

public partial class Program;