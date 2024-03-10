using RichillCapital.Domain;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.ListBots;

internal class ListBotsQueryHandler(
    IReadOnlyRepository<Bot> _botRepository) :
    IQueryHandler<ListBotsQuery, Result<ListDto<BotDto>>>
{
    public async Task<Result<ListDto<BotDto>>> Handle(
        ListBotsQuery query, 
        CancellationToken cancellationToken)
    {
        var bots = await _botRepository.ListAsync(cancellationToken);

        var botDtos = bots
            .Select(bot => new BotDto(
                bot.Id.Value,
                bot.Name.Value,
                bot.Description.Value,
                bot.Symbols
                    .Select(symbol => symbol.Value)
                    .ToArray(),
                bot.Side.Name,
                bot.Platform.Name));

        var listDto = new ListDto<BotDto>(botDtos);

        return listDto.ToResult();
    }
}
