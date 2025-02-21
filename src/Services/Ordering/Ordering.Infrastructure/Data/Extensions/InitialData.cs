using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("e761c0e1-6f6c-4ef5-aaa7-010e76d15a0d")), "Martin Wilson", "martinwilson@mail.com"),
            Customer.Create(CustomerId.Of(new Guid("80e7401f-e0ee-4a96-a56e-ce4195bb6078")), "Ivan Trayanov", "ivantrayanov@mail.com")
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("e1daf916-14c1-4246-8a35-432b67f2d8b5")), "Macbook Air 13", 2500m),
            Product.Create(ProductId.Of(new Guid("4ec763ea-39e7-47fe-b33c-91feee617670")), "Lenovo IdeaPad 3", 1799.99m),
            Product.Create(ProductId.Of(new Guid("2e9a5ea3-b8d5-418f-9c2e-e6be2912fa7d")), "Iphone X", 689.39m),
            Product.Create(ProductId.Of(new Guid("493f4272-a63d-4598-8c9e-afacc85eaedc")), "Iphone 16 Pro Max", 2999.99m)
        };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("Martin", "Wilson", "martinwillson@mail.com", "Sofia", "Bulgaria", null, "1000");
            var address2 = Address.Of("Ivan", "Trayanov", "ivantrayanov@mail.com", "Sofia", "Bulgaria", null, "1000");

            var payment1 = Payment.Of("Martin Wilson", "1111222233334444", "12/31", "123", 1);
            var payment2 = Payment.Of("Ivan Trayanov", "3333111155559999", "03/28", "981", 2);

            var order1 = Order.Create(OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("e761c0e1-6f6c-4ef5-aaa7-010e76d15a0d")),
                OrderName.Of("Order 1"),
                shippingAddress:  address1,
                billingAddress: address1,
                payment1);

            order1.Add(ProductId.Of(new Guid("e1daf916-14c1-4246-8a35-432b67f2d8b5")), 2, 5000m);
            order1.Add(ProductId.Of(new Guid("4ec763ea-39e7-47fe-b33c-91feee617670")), 1, 1799.99m);
            
            var order2 = Order.Create(OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("80e7401f-e0ee-4a96-a56e-ce4195bb6078")),
                OrderName.Of("Order 2"),
                shippingAddress:  address2,
                billingAddress: address2,
                payment2);
            
            order2.Add(ProductId.Of(new Guid("2e9a5ea3-b8d5-418f-9c2e-e6be2912fa7d")), 1, 689.39m);
            order2.Add(ProductId.Of(new Guid("493f4272-a63d-4598-8c9e-afacc85eaedc")), 1, 2999.99m);

            return new List<Order> { order1, order2 };
        }
    }

}