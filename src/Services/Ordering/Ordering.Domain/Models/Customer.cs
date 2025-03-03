namespace Ordering.Domain.Models;

public class Customer : Entity<CustomerId>
{
    private Customer(CustomerId id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public static Customer Create(CustomerId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        return new Customer(id, name, email);
    }
}