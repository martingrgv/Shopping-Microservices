﻿
namespace Catalog.API.Products.GetProduct
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);

    public class GetProductsQueryHandler (IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"{nameof(GetProductsQueryHandler)}.{nameof(Handle)} called with {query}");

            var products = await session.Query<Product>().ToListAsync();
            return new GetProductsResult(products);
        }
    }
}
