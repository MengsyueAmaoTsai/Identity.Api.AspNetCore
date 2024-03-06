using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Domain;

public class UserId : SingleValueObject<string>
{
    private UserId(string value) : base(value)
    {
    }

    public static Result<UserId> From(string value)
    {
        return new UserId(value)
            .ToResult();
    }
}
