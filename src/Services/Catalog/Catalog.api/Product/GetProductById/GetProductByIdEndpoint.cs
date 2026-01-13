
namespace Catalog.api.Product.GetProductById;

//public record GetProductByIdRequest();
public record GetProductByIdResponse(Catalog.api.Models.Product Product);
public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Products/{id}", async (Guid id, ISender sender) =>
        {

            var result = await sender.Send(new GetProductByIdQuery(id));

            var response = result.Adapt<GetProductByIdResponse>();

            return Results.Ok(response);

        }).WithName("GetProductById")
          .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithDescription("Get Product By Id")
          .WithSummary("Get Product By Id");

    }


}
