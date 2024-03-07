using RichillCapital.Domain;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.Get;

internal sealed class GetBotByIdQueryHandler(
    IReadOnlyRepository<Bot> _botRepository) :
    IQueryHandler<GetBotByIdQuery, ErrorOr<BotDto>>
{
    public Task<ErrorOr<BotDto>> Handle(
        GetBotByIdQuery query,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
