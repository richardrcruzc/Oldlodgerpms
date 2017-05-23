using LodgerPms.Domain.Events;
using System; 

namespace LodgerPms.Departments.Api.Events.Departments
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