using Catalog.api.Product.GetProductById;
using System.Linq;

namespace Catalog.api.Product.GetProductByCategory;

public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable< Catalog.api.Models.Product> Products);

internal class GetProductByCategoryQueryHandler
    (IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByCategoryQueryHandler.Handle Called With {@Query}", query);

        var products = await session.Query<Catalog.api.Models.Product>()
            .Where(p=>p.Category.Contains(query.category)).ToListAsync();

        return new GetProductByCategoryResult(products);
    }
}