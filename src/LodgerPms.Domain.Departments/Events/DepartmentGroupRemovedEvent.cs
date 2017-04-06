using System;
using LodgerPms.Domain.Core.Events;

namespace LodgerPms.Domain.Departments.Events
{
    public class DepartmentGroupRemovedEvent : Event
    {
        public DepartmentGroupRemovedEvent(string id)
        {
            Id = id;
            //gregateId = id;
        }

        public string Id { get; set; }
    }
}