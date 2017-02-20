using LodgerPms.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Bookings
{
    public class GuestInfo : Identity
    {
        public static GuestInfo CreateNew( string company, string position, decimal creditLimit,
            Person person, CreditCard payment)
        {
            var obj = new GuestInfo
            {
            Company = company,
            Position = position,
            CreditLimit = creditLimit,
            Person = person,
            Payment = payment
            };
            return obj;

        }

        internal GuestInfo()
        {
            //MediaContact = new Collection<ContactMedia>();
        }

        public bool InHouse { get; private set; }
        public string Company { get; private set; }
        public string Position { get; private set; }
        public decimal CreditLimit { get; private set; }
        public Person Person { get; private set; }

        /// <summary>
        /// Payment details for the guest (whatever that means)
        /// At the very minimum, you might want to use a CreditCard object.
        /// </summary>
        public CreditCard Payment { get; private set; }

        //public void ChangeGuestContactInformation(ContactInformation contactInformation)
        //{
        //    this.Person.ChangeContactInformation(contactInformation);
        //}

        public void ChangeGuestName(FullName personalName)
        {
            this.Person.ChangeName(personalName);
        }

        public override string ToString()
        {
            const string Format = "GuestInfo [company={0}, position={1}, person={2}]";
            return string.Format(Format, this.Company, this.Position, this.Person);
        }
    }
}
