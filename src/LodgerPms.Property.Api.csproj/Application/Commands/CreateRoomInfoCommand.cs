using LodgerPms.Domain.Rooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.Application.Commands
{
   
        [DataContract]
        public class CreateRoomInfoCommand
       : IAsyncRequest<bool>
        {
        [DataMember]
        public RoomInfo RoomInfo { get; private set; }

        public CreateRoomInfoCommand(RoomInfo roomInfo)
        {

            RoomInfo = roomInfo;

        }

    }
}
