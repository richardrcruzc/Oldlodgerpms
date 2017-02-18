using LodgerPms.Domain.Departments;
using LodgerPms.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 Folio with estimated charges for the
entire length of the guest stay.
All guest charges post to one or more folios once the guest is in-house.
     */
namespace LodgerPms.Domain.Bookings
{
    public class GuestFolio : Identity, IAggregateRoot
    {

        public static GuestFolio CreateNew(int Number, Money Currency, string AccountNumber, string RoomNumber)
        {
            var obj = new GuestFolio { };
            return obj;

        }


        protected GuestFolio()
        {
        }
        public bool IsPasserBy { get; private set; }
        public string OwnedBy { get; private set; }
        //usually the folio #1 is OwnedBy the guest and folio # 2 is Owned By agency or company
        public int Number { get; private set; }
        public Money Currency { get; private set; }
        public GuestInfo AccountNumber { get; private set; }
        public string RoomNumber { get; private set; }


        public DateTime TransactionDate { get; private set; }
        public Department Department { get; private set; }
        public DepartmentType DepartmentType { get; private set; }

        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime RevenueDate { get; private set; }


        public bool IsPosted { get; private set; }
        public DateTime PostedDate { get; private set; }
        public string PostedBy { get; private set; }

        public DateTime ChargeDate { get; private set; }
        public string ChargeBy { get; private set; }

        public DateTime ModifiedDate { get; private set; }
        public string ModifiedBy { get; private set; }



    }
}
