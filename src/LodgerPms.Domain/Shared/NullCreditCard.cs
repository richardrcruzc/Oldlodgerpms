using System;

namespace LodgerPms.Domain.Shared
{
    public class NullCreditCard : CreditCard
    {
        public static NullCreditCard Instance = new NullCreditCard();
    }
}