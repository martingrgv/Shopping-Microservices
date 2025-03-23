namespace Shopping.Web.Models.Catalog.EndpointModels;

public record GetProductByCategoryResponse(IEnumerable<ProductModel> Products);
