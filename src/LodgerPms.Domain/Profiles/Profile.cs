using LodgerPms.Domain.Agents;
using LodgerPms.Domain.Rooms;
using LodgerPms.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Profiles
{
    public class Profile : Entity, IAggregateRoot
    {
        public Profile()
        { }

        public string Languaje { get; private set; }
        public string Salutation { get; private set; }

        public string Block { get; private set; }
        public string IATA { get; private set; }
        public string CorporationNumber { get; private set; }
        public string KeyWord { get; private set; }
        public string MemberType { get; private set; }
        public string MemberNumber { get; private set; }

        public Agent Agent { get; private set; }
        public string Company { get; private set; }
        public string Group { get; private set; }
        public string Source { get; private set; }


        public Rate RoomRate { get; private set; }
        public decimal DscountAmount { get; private set; }
        public decimal DscountPercentage { get; private set; }
        public string DscountReason { get; private set; }

        public string AccountReceivableNumber { get; private set; }


        public DateTime Arrival { get; private set; }
        public DateTime Departure { get; private set; }
        public bool VIP { get; private set; }


        public string ReservationType { get; private set; }
        public string Market { get; private set; }
        public string Payment { get; private set; }
        public IEnumerable<CreditCard> CreditCard { get; private set; }


        public RoomType PreferenceRoomType { get; private set; }
        public RoomFacility PreferenceRoomFacility { get; private set; }
        public RoomLocation PreferenceRoomLocation { get; private set; }
        public RoomExposure PreferenceRoomExposure { get; private set; }

        public ProfileType ProfileType { get; private set; }
        public Money PreferedCurrency { get; private set; }
        public ICollection<Person> Person { get; private set; }
        public ICollection<PostalAddress> Address { get; private set; }
        public ICollection<Telephone> Telephone { get; private set; }
        public ICollection<EmailAddress> Email { get; private set; }

        public ICollection<Note> Note { get; private set; }

        public DateTime DateCreated { get; private set; }
        public string CreateBy { get; private set; }
        public DateTime DateModified { get; private set; }
        public string ModifiedBy { get; private set; }

        public ProfileStatus Status { get; private set; }

        public ICollection<ProfileAttribute> Attributes { get; private set; }


    }

    public enum ProfileStatus
    {
        Active = 1,
        Inactive = 2,
        Checkedin = 3,
        Walking = 4,
        CC = 5,
        History = 6,
    }

    public enum ProfileType
    {
        Individual = 1,
        Company = 2,
        TraverAgent = 3,
        Source = 4,
        Group=5,
        Contact=6
    }
}
