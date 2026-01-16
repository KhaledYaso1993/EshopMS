using BuildingBlocks.Exceptions;

namespace Catalog.api.Exceptions
{
    public class ProductNotFoundException:NotFoundException
    {
        public ProductNotFoundException(Guid Id):base("Product",Id)
        {
                
        }
    }
}
