
using LodgerPms.Domain.SeedWork;
using LodgerPms.Property.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Rooms
{
    public class PropertyInfo
      : Entity, IAggregateRoot
    {
        public   PropertyInfo ()
        {
        }

        public Address Address { get; private set; }

        public string Description { get; private set; }
        public string WebSite { get; private set; }
       // public ContactInformation Location { get; private set; }
       // public ContactInformation DefaultBillingAddress { get; private set; }
      //  public ContactInformation DefaultDeliveryAddress { get; private set; }
       //ublic IEnumerable<EmailAddress> Emails { get; private set; }
       // public IEnumerable<Person> Contacts { get; private set; }
        public int RoomQty { get; private set; }

        public string LocationId { get; protected set; }
        public string DefaultBillingAddressId { get; protected set; }
        public string DefaultDeliveryAddressId { get; protected set; }
    }
}
