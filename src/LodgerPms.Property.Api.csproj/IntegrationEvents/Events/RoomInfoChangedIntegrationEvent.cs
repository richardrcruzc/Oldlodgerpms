using LodgerPms.Domain.Rooms;
using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.IntegrationEvents.Events
{
    // Integration Events notes: 
    // An Event is “something that has happened in the past”, therefore its name has to be   
    // An Integration Event is an event that can cause side effects to other microsrvices, Bounded-Contexts or external systems.
    public class RoomInfoChangedIntegrationEvent: IntegrationEvent
    {
        public int RoomInfoId { get; private set; }

        public RoomInfo RoomInfo { get; private set; }

        public RoomInfoChangedIntegrationEvent(RoomInfo roomInfo)
        {
            RoomInfo = roomInfo;
        }

    }
}
