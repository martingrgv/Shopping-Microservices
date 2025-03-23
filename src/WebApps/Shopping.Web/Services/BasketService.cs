namespace Shopping.Web.Services;

public class BasketService
    :  IBasketService
{
    public Task<GetBasketResponse> GetBasket(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<StoreBasketResponse> StoreBasket(StoreBasketRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteBasketResponse> DeleteBasket(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<CheckoutBasketResponse> CheckoutBasket(CheckoutBasketRequest request)
    {
        throw new NotImplementedException();
    }
}