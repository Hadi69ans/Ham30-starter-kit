using FSH.Framework.Core.Domain.Events;
using FSH.Starter.WebApi.Catalog.Domain.Products;

namespace FSH.Starter.WebApi.Catalog.Domain.Products.Events;
public sealed record ProductUpdated : DomainEvent
{
    public Product? Product { get; set; }
}
