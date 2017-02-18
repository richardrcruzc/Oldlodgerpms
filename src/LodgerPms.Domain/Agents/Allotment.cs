using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Agents
{
    public class Allotment: Identity, IAggregateRoot
    {
        public static Allotment CreateNew(Agent agent, DateTime startDate, DateTime endDate, int qty, int cutOff)
        {
            var obj = new Allotment {
                Agent= agent,
                StartDate= startDate,
                EndDate = endDate,
                Qty = qty,
                CutOff= cutOff,
                State = AllotmentState.Active,
            };
            return obj;

        }
        protected Allotment()
        {

        }

        public Agent Agent { get; protected set; }
        public DateTime StartDate  { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public int Qty { get; protected set; }
        public int CutOff { get; protected set; }
        public AllotmentState State { get; protected set; }

        public void ChangeAllotmentStatus(AllotmentState status)
        {
            if (status == State)
            {
                return;
            }
            {
                State = status;
            }

        }
    }
}
