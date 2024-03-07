
using RichillCapital.Domain;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.Create;

public sealed record CreateBotCommand(
    string Id,
    string Name,
    string Description) :
    ICommand<ErrorOr<BotId>>;