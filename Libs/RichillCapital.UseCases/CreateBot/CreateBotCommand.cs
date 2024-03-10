using RichillCapital.Domain;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.CreateBot;

public sealed record CreateBotCommand(
    string Id,
    string Name,
    string Description,
    string[] Symbols,
    string Side,
    string Platform) :
    ICommand<Result<BotId>>;
