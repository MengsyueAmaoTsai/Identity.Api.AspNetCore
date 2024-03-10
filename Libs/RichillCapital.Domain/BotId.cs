using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class BotId : SingleValueObject<string>
{
    public const int MaxLength = 100;

    public BotId(string value)
        : base(value)
    {
    }
}
