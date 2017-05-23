

using LodgerPms.Domain.Rooms;
using MediatR;

namespace LodgerPms.Property.Api.Events
{
    public class RoomInfoAddedDomainEvent : IAsyncNotification
    {
        public RoomInfo RoomInfo { get; private set; }
        public RoomInfoAddedDomainEvent(RoomInfo roomInfo)
        {
            RoomInfo = roomInfo;

        }
    }
}
