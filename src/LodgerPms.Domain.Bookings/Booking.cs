using LodgerPms.Domain.Agents;
using LodgerPms.Domain.Rooms;
using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Bookings
{
    public class Booking : AgregateRoot.BookingState
    {
        public static Booking CreateNew(
         string accountNumber,
         DateTime arriveDate,
         DateTime departureDate,
          bool isComplimentary,
         Rate rate,
         int allotmentQty,
         decimal room,
         decimal service,
         decimal tax,
         decimal extraBed,
         decimal extraBedService,
         decimal extraBedTax,
         decimal lunch,
         decimal dinner,
         decimal discount,
         decimal abf)
        {
            var obj = new Booking
                    {
                            AccountNumber = accountNumber,
                            ArriveDate =arriveDate,
                            DepartureDate = departureDate,
                             IsComplimentary =isComplimentary,
                            Rate =rate,
                            AllotmentQty = allotmentQty,
                            Service = service,
                            Tax =tax,
                            ExtraBed = extraBed,
                            ExtraBedService = extraBedService,
                            ExtraBedTax = extraBedTax,
                            Lunch = lunch,
                            Dinner = dinner,
                            Discount =discount,
                            Abf = abf
                };
            return obj;
        }

        #region Added to please the O/RM

        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        internal Booking()
        {


        }

        #endregion

        public ICollection<GuestInfo> GuestInfoList { get; private set; }
        public RoomInfo RoomInfo { get; private set; }
        public RoomStatus RoomStatus { get; private set; }

        public string AccountNumber { get; private set; }
        public int Adult
        {
            get {
                var adults = (from row in GuestInfoList where row.Person.PersonType == Enums.PersonType.Adult select row).Count() ;

                return adults;
            }
            //private set
            //{

            //    this.Adult = value;
            //}
        }
        public int Child {
            get
            {
                var childs = (from row in GuestInfoList where row.Person.PersonType == Enums.PersonType.Child select row).Count();

                return childs;
            }
        }
        public int Qty { get { return this.Adult + Child; } }
        public DateTime ArriveDate { get; private set; }
        public DateTime DepartureDate { get; private set; }
        public bool IsComplimentary { get; private set; }
        public Rate Rate { get; private set; }
        public int InHouseQty { get { return this.Adult + Child; } }
        public int AllotmentQty { get; private set; }
        public decimal RoomAmount { get; private set; }
        public decimal Service { get; private set; }
        public decimal Tax { get; private set; }
        public decimal ExtraBed { get; private set; }
        public decimal ExtraBedService { get; private set; }
        public decimal ExtraBedTax { get; private set; }
        public decimal Lunch { get; private set; }
        public decimal Dinner { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Abf { get; private set; }

    }
}
