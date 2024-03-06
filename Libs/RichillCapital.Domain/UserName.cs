using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class UserName : SingleValueObject<string>
{
    private UserName(string value) 
        : base(value)
    {
    }
}