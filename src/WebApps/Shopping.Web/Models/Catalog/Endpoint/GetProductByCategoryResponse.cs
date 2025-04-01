namespace Shopping.Web.Models.Catalog.Endpoint;

public record GetProductByCategoryResponse(IEnumerable<ProductModel> Products);
