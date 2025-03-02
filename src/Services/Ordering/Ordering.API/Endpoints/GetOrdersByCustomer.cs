using Azure.Core;
using Ordering.Application.Orders.Queries.GetOrdersByCustomer;

namespace Ordering.API.Endpoints;

public record GetOrdersByCustomerRequest(Guid CustomerId);
public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Order);

public class GetOrdersByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/customer/{customerId}", async (GetOrdersByCustomerRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetOrdersByCustomerQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetOrdersByCustomerResponse>();

                return Results.Ok(response);
            })
        .WithName("GetOrdersByCustomer")
        .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders By Customer")
        .WithDescription("Get Orders By Customer");
    }
}