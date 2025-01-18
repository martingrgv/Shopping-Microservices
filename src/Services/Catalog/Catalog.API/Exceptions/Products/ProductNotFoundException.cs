using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions.Products;

public class ProductNotFoundException(Guid id) : NotFoundException($"Product", id);