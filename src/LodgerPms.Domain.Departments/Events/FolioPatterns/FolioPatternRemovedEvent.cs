using System;
using LodgerPms.Domain.Core.Events;

namespace LodgerPms.Domain.Departments.Events
{
    public class FolioPatternRemovedEvent : Event
    {
        public FolioPatternRemovedEvent(string id)
        {
            Id = id;
            //gregateId = id;
        }

        public string Id { get; set; }
    }
}