using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.Delete;

internal sealed class DeleteBotCommandHandler() :
    ICommandHandler<DeleteBotCommand, Result>
{
    public Task<Result> Handle(
        DeleteBotCommand command,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
