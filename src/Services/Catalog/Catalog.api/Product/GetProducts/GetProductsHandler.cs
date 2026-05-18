using Marten.Pagination;

namespace Catalog.api.Product.GetProducts;

public record GetProductsQuery(int? pageNumber = 1, int? pageSize = 10) : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Catalog.api.Models.Product> Products);
internal class GetProductsHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {

        var products = await session.Query<Catalog.api.Models.Product>().ToPagedListAsync(query.pageNumber??1,query.pageSize??10,cancellationToken);

        return new GetProductsResult(products);
    }
}