using LodgerPms.Domain.Departments;
using LodgerPms.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Agents
{

    public class Rate : Identity, IAggregateRoot
    {
        public static Rate CreateNew( )
        {
            var obj = new Rate
            {

            };
            return obj;

        }
        protected Rate()
        {

        }
        public string RateCode { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string FolioText { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public string Market { get; private set; }
        public string Source { get; private set; }

        public IEnumerable<RoomType> RoomTypes { get; private set; }
        public IEnumerable<Package> Packages { get; private set; }
        public decimal CommissionPercentage { get; private set; }
        public decimal ComissionCode { get; private set; }



        public int MinimumStay { get; private set; }
        public int MaximumStay { get; private set; }
        public int MinimumAdvanceBooking { get; private set; }
        public int MaximumAdvanceBooking { get; private set; }
        public int Multiplication { get; private set; }
        public int Addition { get; private set; }
        public int MinimumOcupancy { get; private set; }
        public int MaximumOcupancy { get; private set; }

        public bool IsComplimentary { get; private set; }
        public bool AllInclusive { get; private set; }
        public RateState State { get; private set; }


        public bool TransactionTax { get; private set; }
        public string TransactionCode { get; private set; }
        public string PKGTrnCode { get; private set; }
        public string ExchangeType { get; private set; }


        public IEnumerable<Components> Components { get; private set; }


        public void ChangeRateState(RateState state)
        {
            if (state == State)
            {
                return;
            }
            {
                State = state;
            }

        }
    }
    public enum Components {
        Package=1,
        Negotiated=2,
        SuppressRate=3,
        PrintRate=4,
        Discount=5,
        MemberShip=6,
        DayUse=7,
        Complimentary=8,
        HouseUse=9,
        DayType=10
    }


    public enum RateState
    {
        Active = 1,
        Canceled = 2,
        Suspended = 3,
        Pending = 4
    }
}
