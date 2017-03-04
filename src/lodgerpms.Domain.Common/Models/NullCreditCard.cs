using System;

namespace lodgerpms.Domain.Common
{
    public class NullCreditCard : CreditCard
    {
        public static NullCreditCard Instance = new NullCreditCard();
    }
}