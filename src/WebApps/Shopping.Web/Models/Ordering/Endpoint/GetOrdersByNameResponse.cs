namespace Shopping.Web.Models.Ordering.Endpoint;

public record GetOrdersByNameResponse(IEnumerable<OrderModel> Orders);