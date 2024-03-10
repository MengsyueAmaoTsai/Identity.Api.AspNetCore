namespace RichillCapital.UseCases;

public sealed record BotDto(
    string Id, 
    string Name, 
    string Description, 
    string[] Symbols, 
    string Side,
    string Platform);
