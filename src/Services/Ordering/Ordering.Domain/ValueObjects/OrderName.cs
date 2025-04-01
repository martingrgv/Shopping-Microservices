namespace Ordering.Domain.ValueObjects;

public record OrderName
{
    private const int DefaultLength = 3;
    
    private OrderName(string value)
    {
        Value = value;
    }
    
    public string Value { get; }

    public static OrderName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfLessThan(value.Length, DefaultLength);

        return new OrderName(value);
    }
}