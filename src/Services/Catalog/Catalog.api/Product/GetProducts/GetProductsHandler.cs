using Marten.Linq.QueryHandlers;

namespace Catalog.api.Product.GetProducts;

public record GetProductsQuery() : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Catalog.api.Models.Product> Products);
internal class GetProductsHandler(IDocumentSession session, ILogger<GetProductsHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsHandler.Handle Called With {@Query}", query);

        var products = await session.Query<Catalog.api.Models.Product>().ToListAsync(cancellationToken);

        return new GetProductsResult(products);
    }
}