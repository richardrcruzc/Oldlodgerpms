using LodgerPms.Property.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Abstractions;
using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Events;
using Microsoft.LodgerPmsContainers.BuildingBlocks.IntegrationEventLogEF.Services;
using Microsoft.LodgerPmsContainers.BuildingBlocks.IntegrationEventLogEF.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.IntegrationEvents
{
    public class RoomInfoIntegrationEventService: IRoomInfoIntegrationEventService
    {

        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventBus _eventBus;
        private readonly PropertyContext _propertyContext;
        private readonly IIntegrationEventLogService _eventLogService;

        public RoomInfoIntegrationEventService(IEventBus eventBus, PropertyContext propertyContext,
       Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory)
        {
            _propertyContext = propertyContext ?? throw new ArgumentNullException(nameof(propertyContext));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventLogServiceFactory(_propertyContext.Database.GetDbConnection());
        }

        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            _eventBus.Publish(evt);

            await _eventLogService.MarkEventAsPublishedAsync(evt);
        }
        public async Task SaveEventAndCatalogContextChangesAsync(IntegrationEvent evt)
        {
            //Use of an EF Core resiliency strategy when using multiple DbContexts within an explicit BeginTransaction():
            //See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
            await ResilientTransaction.New(_propertyContext)
                .ExecuteAsync(async () => {
                    // Achieving atomicity between original catalog database operation and the IntegrationEventLog thanks to a local transaction
                    await _propertyContext.SaveChangesAsync();
                    await _eventLogService.SaveEventAsync(evt, _propertyContext.Database.CurrentTransaction.GetDbTransaction());
                });
        }
    }
}
