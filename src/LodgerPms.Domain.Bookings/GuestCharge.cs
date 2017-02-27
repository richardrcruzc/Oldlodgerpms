using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Bookings
{

    public class GuestCharge : Identity
    {
        public static GuestCharge Create(string accountNumber, DateTime date, decimal amount)
        {
            var obj = new GuestCharge
            {
                AccountNumber = accountNumber,
                Date =date,
                Amount= amount
            };
            return obj;
        }
        #region Added to please the O/RM
        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected GuestCharge()
        {
        }

        #endregion

        public string AccountNumber { get; private set; }
        public DateTime Date { get; private set; }
        public string requirement { get; private set; }
        public decimal Amount { get; private set; }
        public bool Posted { get; private set; }


    }
    public enum DepartmentType
    {
        Debit = 1,
        Credit = 2
    }
}
