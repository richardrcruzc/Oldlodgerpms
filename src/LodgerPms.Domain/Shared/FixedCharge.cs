using System;
 using static LodgerPms.Domain.Shared.Enums;

namespace LodgerPms.Domain.Shared
{
    public class FixedCharge : AgregateRoot.FixedChargeState
    {

        public static FixedCharge New(string transactionCode, Frecuency frecuency, decimal amount, int quantity,
          DateTime begingDate, DateTime endDate, string description)
        {
            var obj = new FixedCharge {
                TransactionCode = transactionCode,
                Frecuency = frecuency,
                Amount = amount,
                Quantity = quantity,
                BegingDate = begingDate,
                EndDate = endDate,
                Description = description,

        };   
            return obj;
        }

        public void Update(string id, string transactionCode, Frecuency frecuency,  decimal amount , int quantity,
          DateTime begingDate, DateTime endDate , string description)
        {
            this.Id = id;
            this.TransactionCode = transactionCode;
            this.Frecuency = frecuency;
            this.Amount = amount;
            this.Quantity = quantity;
            this.BegingDate = begingDate;
            this.EndDate = endDate;
            this.Description = description;
        }
        public FixedCharge()
        {
        }

        public string TransactionCode { get; private set; }

        public Frecuency Frecuency { get; private set; }
        public decimal Amount { get; private set; }
        public int Quantity { get; private set; }


        public DateTime BegingDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public string Description { get; private set; }


    }


}
