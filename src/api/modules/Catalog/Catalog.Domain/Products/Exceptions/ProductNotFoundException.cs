using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Products.Exceptions;
public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid id)
        : base($"product with id {id} not found")
    {
    }
}
