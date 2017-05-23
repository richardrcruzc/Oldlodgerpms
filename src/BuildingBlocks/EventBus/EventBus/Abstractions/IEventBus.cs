using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Events;
using System;
 

namespace Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Abstractions
{
    public interface IEventBus
    {
        void Subscribe<T, TH>(Func<TH> handler)
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;
        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;

        void Publish(IntegrationEvent @event);
    }
}
