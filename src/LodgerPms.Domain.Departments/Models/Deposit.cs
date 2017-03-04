using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments.Models
{
    public class Deposit : Identity
    {
        public static Deposit Create(string accountNumber, string receiptNumber, DateTime date,
                                    decimal amount,string user, bool posted,string folioNumber)
        {
               var obj = new Deposit {
                                AccountNumber = accountNumber ,
                                ReceiptNumber= receiptNumber,
                                Date = date,
                                Amount = amount,
                                User= user,
                                Posted = posted,
                                FolioNumber = folioNumber
               };
            return obj;
        }
        #region Added to please the O/RM
        /// <summary>
        /// Used by the O/RM to materialize objects
        /// </summary>
        protected Deposit()
        {
        }

        #endregion

        public string AccountNumber { get; private set; }
        public string ReceiptNumber { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public string User { get; private set; }
        public bool Posted { get; private set; }
        public string FolioNumber { get; private set; }


    }
}
