using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lodgerpms.Domain.Common.AgregateRoot
{
    public class RoomStatusState : Identity, IAggregateRoot
    {
        public string BookingId { get; private set; }
        public string RoomInfoId { get; private set; }
    }
}
