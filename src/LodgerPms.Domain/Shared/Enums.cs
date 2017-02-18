

namespace LodgerPms.Domain.Shared
{
    public class Enums
    {
        public enum GuestServiceStatus
        {
            DoNotDisturb = 1,
            MakeUpRoom = 2
        }
        public enum ReservationStatus
        {
            Arrivals = 1,
            Arrived = 2,
            StayOver = 3
        }
        public enum HKStatus
        {
            Inspected = 1,/*an additional status some hotels elect to use as the last
                        check by Housekeeping supervisors before making a room available
                        for a guest to occupy */
            Pickup = 2,/*an alternate status some hotels elect to use if Housekeeping
                    attends to rooms that do not need full service (i.e. a guest only
                    occupies a room for a few minutes and the room only needs
                    refreshing) */
            Clean = 3, //the room was serviced and is available for a guest to occupy
            Dirty = 4, //the room is not serviced and is not available for a guest to occupy
            Blocked = 5,
            OutOfOrder = 6,/* the room is not available to sell under any
                        circumstances. Out of Order rooms deduct from inventory;
                        therefore, they affect occupancy calculations. */
            OutOfService = 6, /*functions the same as OOO, but rooms do not
                        deduct from inventory counts. Typically, hotels use the Out of
                        Service status for same day maintenance jobs or Sales show rooms. */
            Available = 7,
            Vacant = 8,
            Queue = 9

        }
        public enum AccountReceivableType
        {
            Corporate = 1,
            Individual = 2,
            Platinum = 3
        }
        public enum PersonType
        {
            Child=1,
            Adult=2,
            Senior=3

        }
        public enum Title
        {
            NA = 0,
            Doctor = 1,
            Family = 2,
            Miss = 3,
            Mr = 4,
            Mrs = 5,
            Ms = 6,
            Professor = 7,
            Khun = 8,
            MrMrs = 9,

        }
        public enum IdentifcationType
        {
            Passport = 1,
            DriverLicense = 2,
            NationalId = 3,

        }
        public enum EntityType
        {
            Profile = 1,
            Guest = 2,
            Folio = 3,
            Transaction = 4,
            Reservation = 5,
        }
        public enum NoteType
        {
            General = 1,
            Complain = 2,
            Reservation = 3
        }
        public enum MessageStatus
        {
            NotReceived = 1,
            Received = 2,
        }
        public enum GenericEntityType
        {
            Language = 1,
            Status = 2,
            Typ3 = 3,


        }
        public enum Gender
        {
            Male = 1,
            Female = 2,
            Unknown = 3
        }
        public enum Frecuency
        {
            Once = 1,
            Daily = 2,
            Weekly = 3,
            Monthly = 4,
            Quartelly = 5,
            Yearly = 6,
        }
        public enum DepositType
        {
            Reservation = 0,
            Guest = 1,
        }
        public enum CreditCardType
        {
            Unknown = 0,
            Visa = 1,
            Mastercard = 2,
            Amex = 3
        }
        public enum ContactType
        {
            Personal = 0,
            Bussiness = 1,
            Billing = 2,
            Shipping = 3,
            Contact = 4
        }

        public enum EmailType
        {
            Personal = 0,
            Bussiness = 1,
            Billing = 2,
            Shipping = 3,
            Contact = 4
        }
    }
}
