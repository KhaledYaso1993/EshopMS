namespace Catalog.api.Product.GetProductById;

public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Catalog.api.Models.Product Product);
internal class GetProductByIdQueryHandler
    (IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Catalog.api.Models.Product > (query.id,cancellationToken);
        
        if (product is null)
        {
            throw new ProductNotFoundException(query.id);
        }

        return new GetProductByIdResult(product);
    }
}
