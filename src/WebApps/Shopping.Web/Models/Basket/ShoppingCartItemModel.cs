namespace Shopping.Web.Models.Basket;

public class ShoppingCartItemModel
{
    public Guid ProductId { get; set; } = Guid.Empty;
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Color { get; set; } = null!;
}