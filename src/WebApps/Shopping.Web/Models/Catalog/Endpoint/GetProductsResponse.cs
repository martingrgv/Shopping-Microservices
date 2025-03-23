namespace Shopping.Web.Models.Catalog.Endpoint;

public record GetProductsResponse(IEnumerable<ProductModel> Products);
