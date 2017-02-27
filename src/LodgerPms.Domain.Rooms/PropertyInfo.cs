using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms
{
    public class PropertyInfo: AgregateRoot.PropertyInfoState
    {
        public   PropertyInfo ()
        {
        }

        public string Description { get; private set; }
        public string WebSite { get; private set; }
        public ContactInformation Location { get; private set; }
        public ContactInformation DefaultBillingAddress { get; private set; }
        public ContactInformation DefaultDeliveryAddress { get; private set; }
        public IEnumerable<EmailAddress> Emails { get; private set; }
        public IEnumerable<Person> Contacts { get; private set; }
        public int RoomQty { get; private set; }

    }
}
