using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static lodgerpms.Domain.Common.Enums;

namespace lodgerpms.Domain.Common
{
    public class Deposit : AgregateRoot.DepositState
    {
        public   Deposit(DepositType type, string rule, decimal percentage, decimal amount ,
            DateTime dueDate , string description)
        {
            this.DepositType = type;
            this.Rule = rule;
            this.Percentage = percentage;
            this.Amount = amount;
            this.DueDate = dueDate;
            this.Description = description;
        }
        public Deposit()
        {
        }
        public DepositType DepositType { get; private set; }
        public string Rule { get; private set; }
        public decimal Percentage { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime DueDate { get; private set; }
        public string Description { get; private set; }
    }
}
