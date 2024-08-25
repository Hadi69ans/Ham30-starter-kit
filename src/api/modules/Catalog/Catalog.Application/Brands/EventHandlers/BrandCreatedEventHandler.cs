using FSH.Starter.WebApi.Catalog.Domain.Brands.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Brands.EventHandlers;

public class BrandCreatedEventHandler(ILogger<BrandCreatedEventHandler> logger) : INotificationHandler<BrandCreated>
{
    public async Task Handle(BrandCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling Brand created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling Brand created domain event..");
    }
}

