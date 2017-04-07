using System;
using LodgerPms.Domain.Core.Events;

namespace LodgerPms.Domain.Departments.Events
{
    public class DepartmentRemovedEvent : Event
    {
        public DepartmentRemovedEvent(string id)
        {
            Id = id;
            //gregateId = id;
        }

        public string Id { get; set; }
    }
}