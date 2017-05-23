
using LodgerPms.Domain.SeedWork;
using System;
 

namespace LodgerPms.Domain.Rooms
{
    public class RoomStatus
      : Entity, IAggregateRoot
    {
        public static RoomStatus Create(RoomInfo room, 
            //Booking boking , 
            Status status, DateTime statusFrom, DateTime statusTo,
            string description, DateTime assignedDate, string assignedby, string reasonCode)
        {
            var roomStatus = new RoomStatus
            {
            //    BookingId = boking.Id,
             //   Booking= boking,
                RoomInfo = room,
                RoomInfoId=room.Id,
                Description =description,
                Status =status,
                StatusFrom = statusFrom ,
                StatusTo =statusTo,
                AssignedDate = assignedDate,

                Assignedby= assignedby,
                ReasonCode = reasonCode,
            };
            return roomStatus;

        }
        public void Update(RoomInfo room,
            //Booking boking, 
            Status status, DateTime statusFrom, DateTime statusTo,
            string description, DateTime assignedDate, string assignedby, string reasonCode)
        {
            //BookingId = boking.Id;
            //Booking = boking;
            RoomInfo = room;
            RoomInfoId = room.Id;
            Description = description;
            Status = status;
            StatusFrom = statusFrom;
            StatusTo = statusTo;

            AssignedDate = assignedDate;
            Assignedby = assignedby;
            ReasonCode = reasonCode;
        }
        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected RoomStatus()
        {
        }

        #endregion

        //HK = house keeping
        //update house keeping status
        //public RoomStatus SetHouseKeepingStatus(HKStatus hKStatus)
        //{
        //    HKStatus = hKStatus;
        //    return this;
        //}
        //public RoomStatus SetGuestServiceStatus(GuestServiceStatus guestServiceStatus)
        //{
        //    GuestServiceStatus = guestServiceStatus;
        //    return this;
        //}

        public string BookingId { get; protected set; }
        public string RoomInfoId { get; protected set; }

        public RoomInfo RoomInfo { get; private set; }
       // public ReservationStatus ReservationStatus { get; private set; }
        public Status Status { get; private set; }
       // public GuestServiceStatus GuestServiceStatus { get; private set; }
      //  public HKStatus HKStatus { get; private set; }
        public DateTime StatusFrom { get; private set; }
        public DateTime StatusTo { get; private set; }
        public string Description { get; private set; }
        public int NumberOfPerson { get; private set; }
        public int HKNumberOfPerson { get; private set; }

        public DateTime AssignedDate { get; private set; }
        public string Assignedby { get; private set; }
        public string AssignedTo { get; private set; }
        public string ReasonCode { get; private set; }

    }

}
