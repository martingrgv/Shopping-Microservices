using MassTransit;
using Microsoft.Extensions.Logging;

namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger, IPublishEndpoint publishEndpoint)
    : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType());

        var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();
        
        await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
    }
}