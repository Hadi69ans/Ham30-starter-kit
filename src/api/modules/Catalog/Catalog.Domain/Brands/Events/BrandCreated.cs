using FSH.Starter.WebApi.Catalog.Domain.Brands;
using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Brands.Events;
public sealed record BrandCreated : DomainEvent
{
    public Brand? Brand { get; set; }
}
