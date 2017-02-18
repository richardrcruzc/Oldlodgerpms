
namespace LodgerPms.Domain.Bookings.AgregateRoot
{
    public class BookingState:Identity
    {
        public string RoomInfoId { get; set; }
        public string RoomStatusId { get; set; }
        public string RateId { get; set; }
    }
}
