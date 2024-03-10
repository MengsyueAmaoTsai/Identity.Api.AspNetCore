using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.GetBotById;

public sealed record GetBotByIdQuery(string Id) :
    IQuery<Result<BotDto>>;
