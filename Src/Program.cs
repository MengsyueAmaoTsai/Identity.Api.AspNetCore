using RichillCapital.Identity.Api;
using RichillCapital.Persistence;
using RichillCapital.UseCases;

var builder = WebApplication
    .CreateBuilder(args);

builder.Services.AddUseCases();
builder.Services.AddPersistence();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.PopulateSeed();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();

public partial class Program;