using RichillCapital.Domain;
using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.CreateBot;

internal sealed class CreateBotCommandHandler(
    IRepository<Bot> _botRepository,
    IUnitOfWork _unitOfWork) :
    ICommandHandler<CreateBotCommand, Result<BotId>>
{
    public async Task<Result<BotId>> Handle(
        CreateBotCommand command,
        CancellationToken cancellationToken)
    {
        var id = BotId.From(command.Id);

        if (id.IsFailure)
        {
            return id.Error.ToResult<BotId>();
        }

        if (await _botRepository.AnyAsync(bot => bot.Id == id.Value, cancellationToken))
        {
            return Error.Conflict("Bot with given id already exists.").ToResult<BotId>();
        }

        var name = BotName.From(command.Name);

        if (name.IsFailure)
        {
            return name.Error.ToResult<BotId>();
        }

        if (await _botRepository.AnyAsync(bot => bot.Name == name.Value, cancellationToken))
        {
            return Error.Conflict("Bot with given name already exists.").ToResult<BotId>();
        }

        var symbols = command.Symbols
            .Select(Symbol.From)
            .ToArray();

        if (symbols.Any(symbol => symbol.IsFailure))
        {
            return symbols.First(symbol => symbol.IsFailure).Error.ToResult<BotId>();
        }

        var side = Side.FromName(command.Side);

        if (side.IsNull)
        {
            return Error.Invalid("Invalid side").ToResult<BotId>();
        }

        var platform = TradingPlatform.FromName(command.Platform);

        if (platform.IsNull)
        {
            return Error.Invalid("Invalid platform").ToResult<BotId>();
        }

        var bot = new Bot(
            id.Value,
            name.Value,
            new BotDescription(command.Description),
            symbols
                .Select(symbol => symbol.Value).ToArray(),
            side.Value,
            platform.Value);

        _botRepository.Add(bot);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return bot.Id.ToResult();
    }
}