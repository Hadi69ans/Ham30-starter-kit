using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Brands.Exceptions;
public sealed class BrandNotFoundException : NotFoundException
{
    public BrandNotFoundException(Guid id)
        : base($"Brand with id {id} not found")
    {
    }
}
