using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Events;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.IntegrationEvents
{
    public interface IRoomInfoIntegrationEventService
    {
        Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt);
        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
