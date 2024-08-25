using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain.Brands;
using FSH.Starter.WebApi.Catalog.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence;
internal sealed class CatalogDbInitializer(
    ILogger<CatalogDbInitializer> logger,
    CatalogDbContext context) : IDbInitializer
{
    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        if ((await context.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
        {
            await context.Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] applied database migrations for catalog module", context.TenantInfo!.Identifier);
        }
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {


        const string BrandName = "First Brand";
        const string BrandDescription = "Test Brand";

        if (await context.Brands.FirstOrDefaultAsync(t => t.Name == BrandName, cancellationToken).ConfigureAwait(false) is null)
        {
            var brand = Brand.Create(BrandName, BrandDescription);
            await context.Brands.AddAsync(brand, cancellationToken);

            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default catalog:brand data", context.TenantInfo!.Identifier);
        }


        const string ProductName = "First Product";
        const string ProductDescription = "Test Product";
        const decimal ProductPrice = 100;
        if (await context.Products.FirstOrDefaultAsync(t => t.Name == ProductName, cancellationToken).ConfigureAwait(false) is null)
        {
            var product = Product.Create(ProductName, ProductDescription, ProductPrice);
            await context.Products.AddAsync(product, cancellationToken);

            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("[{Tenant}] seeding default catalog:product data", context.TenantInfo!.Identifier);
        }
    }
}
