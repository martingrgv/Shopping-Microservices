using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Web.Models.Ordering;

namespace Shopping.Web.Pages;

public class OrderListModel(IOrderService orderService)
    : PageModel
{
    public IEnumerable<OrderModel> Orders { get; set; } = null!;
    
    public async Task<IActionResult> OnGetAsync()
    {
        var customerId = new Guid("e761c0e1-6f6c-4ef5-aaa7-010e76d15a0d");

        var response = await orderService.GetOrdersByCustomer(customerId);
        Orders = response.Orders;
            
         return Page();
    }
}