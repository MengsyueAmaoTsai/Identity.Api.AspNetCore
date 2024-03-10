using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.UseCases.ListBots;

public class ListBotsQuery : 
    IQuery<Result<ListDto<BotDto>>>;

internal record ListDto<T>(IEnumerable<T> Items);