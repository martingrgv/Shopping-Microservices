using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Models.Basket;
using Shopping.Web.Models.Catalog;

namespace Shopping.Web.Pages;

public class IndexModel(ICatalogService catalogService, IBasketService basketService, ILogger<IndexModel> logger)
    : PageModel
{
    public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();

    public async Task<IActionResult> OnGet()
    {
        logger.LogInformation("Index page visited");
        var result = await catalogService.GetProducts();
        ProductList = result.Products;
        
        return Page();
    }

    public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
    {
        logger.LogInformation("Add to cart button clicked");
        
        var productResponse = await catalogService.GetProductById(productId);

        var basket = await basketService.LoadUserBasket();
        
        basket.Items.Add(new ShoppingCartItemModel()
        {
            ProductId = productId,
            ProductName = productResponse.Product.Name,
            Price = productResponse.Product.Price,
            Quantity = 1,
            Color = "Black"
        });

        return RedirectToPage("Cart");
    }
}
