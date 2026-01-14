namespace Catalog.api.Product.GetProductByCategory;

//public record GetProductByCategoryRequest();
public record GetProductByCategoryResponse(IEnumerable<Catalog.api.Models.Product> Products);
public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Products/category/{Category}", async (string category, ISender sender) =>
        {

            var result = await sender.Send(new GetProductByCategoryQuery(category));

            var response = result.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(response);

        }).WithName("GetProductCategoryId")
          .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status400BadRequest)
          .WithDescription("Get Product By Category")
          .WithSummary("Get Product By Category");

    }

}





