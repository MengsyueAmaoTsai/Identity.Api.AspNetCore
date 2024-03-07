using RichillCapital.Domain;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.List;

internal sealed class ListBotsQueryHandler(
    IReadOnlyRepository<Bot> _botRepository) :
    IQueryHandler<ListBotsQuery, ErrorOr<PagedDto<BotDto>>>
{
    public async Task<ErrorOr<PagedDto<BotDto>>> Handle(
        ListBotsQuery query,
        CancellationToken cancellationToken)
    {
        var bots = await _botRepository.ListAsync(cancellationToken);

        var items = bots
            .Select(BotDto.From);

        return new PagedDto<BotDto>(items)
            .ToErrorOr();
    }
}
