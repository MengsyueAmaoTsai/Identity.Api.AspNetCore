using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class Email : SingleValueObject<string>
{
    public const int MaxLength = 100;

    private Email(string value) 
        : base(value)
    {
    }
}
