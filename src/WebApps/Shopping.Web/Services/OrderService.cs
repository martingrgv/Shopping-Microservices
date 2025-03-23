namespace Shopping.Web.Services;

public class OrderService
    : IOrderService
{
    public Task<GetOrdersResponse> GetOrders(int? pageIndex, int? pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<GetOrdersByNameResponse> GetOrdersByName(string orderName)
    {
        throw new NotImplementedException();
    }

    public Task<GetOrdersByCustomerResponse> GetOrdersByCustomer(Guid customerId)
    {
        throw new NotImplementedException();
    }
}