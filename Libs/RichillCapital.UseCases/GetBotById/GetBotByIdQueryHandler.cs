using RichillCapital.Domain;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.GetBotById;

internal sealed class GetBotByIdQueryHandler(
    IReadOnlyRepository<Bot> _botRepository) :
    IQueryHandler<GetBotByIdQuery, Result<BotDto>>
{
    public async Task<Result<BotDto>> Handle(
        GetBotByIdQuery query,
        CancellationToken cancellationToken)
    {
        var id = BotId.From(query.Id);

        if (id.IsFailure)
        {
            return id.Error.ToResult<BotDto>();
        }

        var bot = await _botRepository.GetByIdAsync(id.Value, cancellationToken);

        if (bot.IsNull)
        {
            return Error.NotFound("Bot with given id was not found.").ToResult<BotDto>();
        }

        var botDto = BotDto.FromDomain(bot.Value);

        return botDto.ToResult();
    }
}