using RichillCapital.Domain;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.DeleteBot;

internal sealed class DeleteBotCommandHandler(
    IRepository<Bot> _botRepository,
    IUnitOfWork _unitOfWork) :
    ICommandHandler<DeleteBotCommand, Result>
{
    public async Task<Result> Handle(
        DeleteBotCommand command,
        CancellationToken cancellationToken)
    {
        var id = BotId.From(command.Id);

        if (id.IsFailure)
        {
            return id.Error.ToResult();
        }

        var bot = await _botRepository.GetByIdAsync(id.Value, cancellationToken);

        if (bot.IsNull)
        {
            return Error.NotFound("Bot with given id was not found.").ToResult();
        }

        _botRepository.Remove(bot.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}