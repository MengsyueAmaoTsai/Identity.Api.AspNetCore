using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.DeleteBot;

public sealed record DeleteBotCommand(string Id) :
    ICommand<Result>;
