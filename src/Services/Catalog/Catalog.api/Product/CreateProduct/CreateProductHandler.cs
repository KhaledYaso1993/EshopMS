using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Catalog.api.Product.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage(errorMessage: "ImageFile is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be Greater Than zero");

    }
}
internal class CreateProductCommandHandler(IDocumentSession session, ILogger<CreateProductCommandHandler> logger)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("CreateProductCommandHandler.Handle Called With {@command}", command);
        //Create Product Entity

        var product = new Catalog.api.Models.Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };
        //TODO
        //Save Product
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        //Retuern response
        return new CreateProductResult(product.Id);
    }

}



