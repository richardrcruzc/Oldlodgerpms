using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms.AgregateRoot
{
    public abstract class PropertyInfoState: Identity, IAggregateRoot
    {
        public string LocationId { get; protected set; }
        public string DefaultBillingAddressId { get; protected set; }
        public string DefaultDeliveryAddressId { get; protected set; }
         
    }
}
