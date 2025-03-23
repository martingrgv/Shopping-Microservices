namespace Shopping.Web.Models.Catalog.EndpointModels;

public record GetProductsResponse(IEnumerable<ProductModel> Products);
