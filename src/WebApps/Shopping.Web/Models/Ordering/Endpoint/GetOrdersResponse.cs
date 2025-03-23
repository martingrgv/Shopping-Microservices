namespace Shopping.Web.Models.Ordering.Endpoint;

public record GetOrdersResponse(PaginatedResult<OrderModel> Orders);