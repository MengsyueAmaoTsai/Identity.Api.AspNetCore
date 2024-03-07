using RichillCapital.Domain;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.Get;

internal sealed class GetBotByIdQueryHandler(
    IReadOnlyRepository<Bot> _botRepository) :
    IQueryHandler<GetBotByIdQuery, ErrorOr<BotDto>>
{
    public async Task<ErrorOr<BotDto>> Handle(
        GetBotByIdQuery query,
        CancellationToken cancellationToken)
    {
        var idResult = BotId.From(query.Id);

        if (idResult.IsFailure)
        {
            return idResult.Error.ToErrorOr<BotDto>();
        }

        var maybeBot = await _botRepository.GetByIdAsync(idResult.Value, cancellationToken);

        if (maybeBot.IsNull)
        {
            return Error.NotFound("Bot not found").ToErrorOr<BotDto>();
        }

        var bot = maybeBot.Value;

        var botDto = new BotDto(
            bot.Id.Value,
            bot.Name.Value,
            bot.Description.Value,
            bot.Side.Name,
            bot.Platform.Name,
            bot.CreatedAt,
            bot.UpdatedAt);

        return botDto.ToErrorOr();
    }
}
