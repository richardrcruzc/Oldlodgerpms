using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms.AgregateRoot
{
    public class PropertyInfoState: Identity, IAggregateRoot
    {
        public string LocationId { get; set; }
        public string DefaultBillingAddressId { get; set; }
        public string DefaultDeliveryAddressId { get; set; }
         
    }
}
