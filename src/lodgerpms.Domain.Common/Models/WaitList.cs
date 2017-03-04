using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lodgerpms.Domain.Common
{

        public class WaitList : Identity
    {
        public WaitList(WaitListReason reason , WaitListPriority priority, string description,
            DateTime dateCreated, string createBy)
        {
            this.Reason=reason;
            this.Priority = priority;
            this.Description = description;
            this.DateCreated = dateCreated;
            this.CreateBy = createBy;

        }

        public WaitList() { }
        public WaitListReason Reason { get; private set; }
        public WaitListPriority Priority { get; private set; }
        public EmailAddress Email { get; private set; }
        public Telephone Phone { get; private set; }

        public string Description { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string CreateBy { get; private set; }

    }
    public enum WaitListReason
    {
        SoldOut = 1,
    }
    public enum WaitListPriority
    {
        VIP = 1,
        Normal = 2,
    }

}

