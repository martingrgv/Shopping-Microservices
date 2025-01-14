namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id): IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);

    public class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductByIdHandler> logger)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"{nameof(GetProductByIdHandler)}.{nameof(Handle)} called with {query}");
            
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException();
            }
            
            return new GetProductByIdResult(product);
        }
    }
}
