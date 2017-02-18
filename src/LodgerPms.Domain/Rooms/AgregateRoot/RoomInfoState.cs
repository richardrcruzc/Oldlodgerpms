﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms.AgregateRoot
{
     public class RoomInfoState : Identity
    {
        public string RoomTypeId { get; set; }
        public string BedTypeId { get; set; }
        public string RoomLocationId { get; set; }
    }
}
