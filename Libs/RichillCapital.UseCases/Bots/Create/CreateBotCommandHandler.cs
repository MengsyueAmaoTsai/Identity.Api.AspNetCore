
using RichillCapital.Domain;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.Create;

internal sealed class CreateBotCommandHandler :
    ICommandHandler<CreateBotCommand, ErrorOr<BotId>>
{
    public Task<ErrorOr<BotId>> Handle(
        CreateBotCommand command,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
