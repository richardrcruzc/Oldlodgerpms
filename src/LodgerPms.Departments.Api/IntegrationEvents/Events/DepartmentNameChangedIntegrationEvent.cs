
using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.IntegrationEvents.Events
{
   
    // Integration Events notes: 
    // An Event is “something that has happened in the past”, therefore its name has to be   
    // An Integration Event is an event that can cause side effects to other microsrvices, Bounded-Contexts or external systems.
    public class DepartmentNameChangedIntegrationEvent : IntegrationEvent
    {
        public string DepartmentId { get; private set; }

        public string NewName { get; private set; }

        public string OldName { get; private set; }

        public DepartmentNameChangedIntegrationEvent(string departmentId, string newName, string oldName)
        {
            DepartmentId = departmentId;
            NewName = newName;
            OldName = oldName;

        }
    }
}
