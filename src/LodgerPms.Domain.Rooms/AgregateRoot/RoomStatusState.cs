using lodgerpms.Domain.Common;

namespace LodgerPms.Domain.Rooms.AgregateRoot
{
    public abstract class RoomStatusState:Identity, IAggregateRoot
    {
        public string BookingId { get; protected set; }
        public string RoomInfoId { get; protected set; }
    }
}
