﻿using FSH.Starter.WebApi.Catalog.Domain.Brands;
using FSH.Framework.Core.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FSH.Starter.WebApi.Catalog.Domain.Brands.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Application.Brands.Delete.v1;
public sealed class DeleteBrandHandler(
    ILogger<DeleteBrandHandler> logger,
    [FromKeyedServices("catalog:brands")] IRepository<Brand> repository)
    : IRequestHandler<DeleteBrandCommand>
{
    public async Task Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var brand = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = brand ?? throw new BrandNotFoundException(request.Id);
        await repository.DeleteAsync(brand, cancellationToken);
        logger.LogInformation("brand with id : {BrandId} deleted", brand.Id);
    }
}
