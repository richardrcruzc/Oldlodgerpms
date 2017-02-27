using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms.AgregateRoot
{
    public class RoomFacilityState : Identity, IAggregateRoot
    {
        public string RoomId { get; set; }
        public string FacilityId { get; set; }
    }
}
