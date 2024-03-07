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
            .Select(bot => new BotDto(
                bot.Id.Value,
                bot.Name.Value,
                bot.Description.Value));

        return new PagedDto<BotDto>(items)
            .ToErrorOr();
    }
}
