namespace Shopping.Web.Models.Ordering.Endpoint;

public record GetOrdersByCustomerResponse(IEnumerable<OrderModel> Orders);