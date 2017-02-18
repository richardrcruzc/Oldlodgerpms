using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms.AgregateRoot
{
    public class RoomStatusState:Identity
    {
        public string BookingId { get; set; }
        public string RoomInfoId { get; set; }
    }
}
