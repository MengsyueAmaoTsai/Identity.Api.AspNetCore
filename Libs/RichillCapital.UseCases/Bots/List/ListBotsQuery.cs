using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.List;

public sealed record ListBotsQuery() :
    IQuery<ErrorOr<PagedDto<BotDto>>>;
