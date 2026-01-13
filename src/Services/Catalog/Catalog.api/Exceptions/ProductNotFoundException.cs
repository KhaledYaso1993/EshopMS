namespace Catalog.api.Exceptions
{
    public class ProductNotFoundException:Exception
    {
        public ProductNotFoundException():base("Product Not Forund")
        {
                
        }
    }
}
