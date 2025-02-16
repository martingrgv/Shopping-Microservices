namespace Ordering.Domain.Models;

public class Product : Entity<ProductId>
{
    private Product(ProductId id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
    
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;

    public static Product Create(ProductId id, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        return new Product(id, name, price);
    }
}