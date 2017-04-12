using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Events; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.IntegrationEvents
{
    public interface IDepartmentIntegrationEventService
    {
        Task SaveEventAndDeptoContextChangesAsync(IntegrationEvent evt);
        Task PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
