using Shopping.Web.Models.Catalog.Endpoint;

namespace Shopping.Web.Services;

public class CatalogService
    : ICatalogService
{
    public Task<GetProductsResponse> GetProducts(int? pageNumber, int? pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<GetProductByIdResponse> GetProductById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<GetProductByCategoryResponse> GetProductByCategory(string category)
    {
        throw new NotImplementedException();
    }
}