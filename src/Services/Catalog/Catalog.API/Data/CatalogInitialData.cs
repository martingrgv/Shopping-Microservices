using Marten.Schema;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellationToken)
    {
        await using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellationToken))
        {
            return;
        }

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellationToken);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new Product[]
    {
        new Product
        {
            Id = new Guid("8d42735e-ab63-45bd-8c7a-b77ac7c82c18"),
            Name = "Macbook Air 13",
            Description = "8-Core CPU\n8-Core GPU\n16GB Unified Memory\n256GB SSD Storage footnote \u00b9",
            ImageFile = "macbook-air-13.png",
            Price = 999.00m,
            Category = { "Laptops" },
        },
        new Product
        {
            Id = new Guid("16a14351-c902-445a-9921-babe79034d44"),
            Name = "Macbook Air 15",
            Description = "8-Core CPU\n10-Core GPU\n16GB Unified Memory\n256GB SSD Storage footnote \u00b9",
            ImageFile = "macbook-air-15.png",
            Price = 1299.00m,
            Category = { "Laptops" },
        },
        new Product
        {
            Id = new Guid("6a2efc59-f337-4c70-b2b3-7cddce90f556"),
            Name = "Macbook Pro 14",
            Description = "10-Core CPU\n10-Core GPU\n16GB Unified Memory\n512GB SSD Storage \u00b9",
            ImageFile = "macbook-pro-14.png",
            Price = 1599.00m,
            Category = { "Laptops" },
        },
        new Product
        {
            Id = new Guid("ddf07e76-6c03-43b9-838a-e4c7c4461c54"),
            Name = "Macbook Pro 16",
            Description = "14-Core CPU\n20-Core GPU\n24GB Unified Memory\n512GB SSD Storage \u00b9",
            ImageFile = "macbook-pro-16.png",
            Price = 2499.00m,
            Category = { "Laptops" },
        },
    };
}