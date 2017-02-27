using lodgerpms.Domain.Common;

namespace LodgerPms.Domain.Rooms.AgregateRoot
{
    public class RoomStatusState:Identity, IAggregateRoot
    {
        public string BookingId { get; set; }
        public string RoomInfoId { get; set; }
    }
}
