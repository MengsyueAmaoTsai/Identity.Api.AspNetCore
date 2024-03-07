
using RichillCapital.Domain;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.Create;

internal sealed class CreateBotCommandHandler(
    IRepository<Bot> _botRepository,
    IUnitOfWork _unitOfWork) :
    ICommandHandler<CreateBotCommand, ErrorOr<BotId>>
{
    public async Task<ErrorOr<BotId>> Handle(
        CreateBotCommand command,
        CancellationToken cancellationToken)
    {
        var idResult = BotId.From(command.Id);

        if (idResult.IsFailure)
        {
            return idResult.Error.ToErrorOr<BotId>();
        }

        var nameResult = BotName.From(command.Name);

        if (nameResult.IsFailure)
        {
            return nameResult.Error.ToErrorOr<BotId>();
        }

        var descriptionResult = BotDescription.From(command.Description);

        if (descriptionResult.IsFailure)
        {
            return descriptionResult.Error.ToErrorOr<BotId>();
        }

        var sideResult = Side.FromName(command.Side);

        if (sideResult.IsNull)
        {
            return Error.Invalid("Side not found").ToErrorOr<BotId>();
        }

        var platformResult = TradingPlatform.FromName(command.Platform);

        if (platformResult.IsNull)
        {
            return Error.Invalid("Platform not found").ToErrorOr<BotId>();
        }

        var errorOrBot = Bot.Create(
            idResult.Value,
            nameResult.Value,
            descriptionResult.Value,
            sideResult.Value,
            platformResult.Value);

        if (errorOrBot.HasError)
        {
            return errorOrBot.Errors.ToErrorOr<BotId>();
        }

        _botRepository.Add(errorOrBot.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return errorOrBot.Value.Id.ToErrorOr();
    }
}
