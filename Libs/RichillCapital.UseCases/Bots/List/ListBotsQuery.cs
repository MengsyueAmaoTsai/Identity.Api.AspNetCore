using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.List;

internal sealed record ListBotsQuery() :
    IQuery<ErrorOr<PagedDto<BotDto>>>;
