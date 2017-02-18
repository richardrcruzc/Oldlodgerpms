using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Shared.AgregateRoot
{
    public class RoomStatusState : Identity
    {
        public string BookingId { get; private set; }
        public string RoomInfoId { get; private set; }
    }
}
