using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms.AgregateRoot
{
    public class RoomTypeState : Identity, IAggregateRoot
    {
        public string RoomGroupId { get; set; }
    }
}
