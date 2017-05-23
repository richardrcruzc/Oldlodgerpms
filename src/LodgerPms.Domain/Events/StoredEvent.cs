using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Events
{
    public class StoredEvent : Event
    {
        public StoredEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid().ToString();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
        }

        // EF Constructor
        protected StoredEvent() { }

        public string Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }
    }
}
