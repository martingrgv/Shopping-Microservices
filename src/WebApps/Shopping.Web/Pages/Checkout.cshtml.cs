using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Models.Basket;

namespace Shopping.Web.Pages;

public class CheckoutModel(IBasketService basketService, ILogger<CheckoutModel> logger)
    : PageModel
{
    [BindProperty]
    public BasketCheckoutModel Order { get; set; } = null!;

    public ShoppingCartModel Cart { get; set; } = null!;
    
    public async Task<IActionResult> OnGetAsync()
    {
        Cart = await basketService.LoadUserBasket();
        
        return Page();
    }

    public async Task<IActionResult> OnPostCheckOutAsync()
    {
        logger.LogInformation("Checkout button clicked");

        Cart = await basketService.LoadUserBasket();

        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        Order.CustomerId = new Guid("e761c0e1-6f6c-4ef5-aaa7-010e76d15a0d");
        Order.UserName = Cart.UserName;
        Order.TotalPrice = Cart.TotalPrice;
        
        await basketService.CheckoutBasket(new CheckoutBasketRequest(Order));

        return RedirectToPage("Confirmation", "OrderSubmitted");
    }
}