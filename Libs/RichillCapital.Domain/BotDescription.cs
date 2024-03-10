using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class BotDescription : SingleValueObject<string>
{
    public const int MaxLength = 100;

    public BotDescription(string value)
        : base(value)
    {
    }
}
