
using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Abstractions;
using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Events;
using Microsoft.LodgerPmsContainers.BuildingBlocks.IntegrationEventLogEF.Services;
using Microsoft.LodgerPmsContainers.BuildingBlocks.IntegrationEventLogEF.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using LodgerPms.Service.Departments.Api.Infrastructure;

namespace LodgerPms.Departments.Api.IntegrationEvents
{
    public class DepartmentIntegrationEventService: IDepartmentIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventBus _eventBus;
        private readonly DepartmentContext _departmentContext;
        private readonly IIntegrationEventLogService _eventLogService;

        public DepartmentIntegrationEventService(IEventBus eventBus, DepartmentContext departmentContext,
       Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory)
        {
            _departmentContext = departmentContext ?? throw new ArgumentNullException(nameof(DepartmentContext));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventLogServiceFactory(_departmentContext.Database.GetDbConnection());
        }

        public async Task PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            _eventBus.Publish(evt);
            await _eventLogService.MarkEventAsPublishedAsync(evt);
        }

        public async Task SaveEventAndDeptoContextChangesAsync(IntegrationEvent evt)
        {
            //Use of an EF Core resiliency strategy when using multiple DbContexts within an explicit BeginTransaction():
            //See: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency            
            await ResilientTransaction.New(_departmentContext)
                .ExecuteAsync(async () => {
                    // Achieving atomicity between original catalog database operation and the IntegrationEventLog thanks to a local transaction
                    await _departmentContext.SaveChangesAsync();
                    await _eventLogService.SaveEventAsync(evt, _departmentContext.Database.CurrentTransaction.GetDbTransaction());
                });
        }

    }
}
