
using Catalog.api.Product.CreateProduct;

namespace Catalog.api.Product.DeleteProduct;

//public record  DeleteProductRequest();
public record DeleteProductResponse(bool IsSuccess);


public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/Products/{id}", async (Guid id, ISender sender) =>
        {

            var result = await sender.Send(new DeleteProductCommand(id));

            var Response = result.Adapt<DeleteProductResponse>();

            return Results.Ok(Response);

        }).WithName("DeleteProduct")
            .Produces<DeleteProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
    }
}
