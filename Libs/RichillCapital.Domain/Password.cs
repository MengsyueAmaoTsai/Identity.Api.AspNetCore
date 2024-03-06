using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class Password : SingleValueObject<string>
{
    private Password(string value) 
        : base(value)
    {
    }
}
