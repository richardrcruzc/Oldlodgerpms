using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms.AgregateRoot
{
     public abstract class RoomInfoState : Identity, IAggregateRoot
    {
        public string RoomTypeId { get; protected set; }
        public string BedTypeId { get; protected set; }
        public string RoomLocationId { get; protected set; }
    }
}
