using FSH.Starter.WebApi.Catalog.Application.Brands.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain.Brands;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Specifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace FSH.Starter.WebApi.Catalog.Application.Brands.Search.v1;
public sealed class SearchBrandsHandler(
    [FromKeyedServices("catalog:brands")] IReadRepository<Brand> repository)
    : IRequestHandler<SearchBrandsCommand, PagedList<BrandResponse>>
{
    public async Task<PagedList<BrandResponse>> Handle(SearchBrandsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new EntitiesByPaginationFilterSpec<Brand, BrandResponse>(request.filter);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<BrandResponse>(items, request.filter.PageNumber, request.filter.PageSize, totalCount);
    }
}

