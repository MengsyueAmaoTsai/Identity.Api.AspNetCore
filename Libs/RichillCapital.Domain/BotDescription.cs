using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public sealed class BotDescription : SingleValueObject<string>
{
    private BotDescription(string value)
        : base(value)
    {
    }

    public static Result<BotDescription> From(string value) => throw new NotImplementedException();
}