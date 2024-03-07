using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.Bots.Delete;

public sealed record DeleteBotCommand(string BotId) : ICommand<Result>;