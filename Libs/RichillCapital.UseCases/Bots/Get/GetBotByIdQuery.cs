using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.Get;

public sealed record GetBotByIdQuery(string Id) :
    IQuery<ErrorOr<BotDto>>;