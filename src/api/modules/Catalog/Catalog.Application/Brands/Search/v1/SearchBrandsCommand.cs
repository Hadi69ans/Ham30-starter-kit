using FSH.Starter.WebApi.Catalog.Application.Brands.Get.v1;
using FSH.Framework.Core.Paging;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Brands.Search.v1;

public record SearchBrandsCommand(PaginationFilter filter) : IRequest<PagedList<BrandResponse>>;
