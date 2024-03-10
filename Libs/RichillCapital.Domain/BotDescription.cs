using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class BotDescription : SingleValueObject<string>
{
    public BotDescription(string value) 
        : base(value)
    {
    }
}
