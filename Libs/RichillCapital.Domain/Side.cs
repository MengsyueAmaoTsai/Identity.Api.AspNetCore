using RichillCapital.SharedKernel;

namespace RichillCapital.Domain;

public sealed class Side : Enumeration<Side>
{
    public static readonly Side Long = new(nameof(Long), 1);
    public static readonly Side Short = new(nameof(Short), -1);

    private Side(string name, int value)
        : base(name, value)
    {
    }
}