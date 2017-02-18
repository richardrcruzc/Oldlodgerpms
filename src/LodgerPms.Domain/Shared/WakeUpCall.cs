using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 The Wake-Up Calls function allows you to set, view, and delete wake up calls
for rooms, guests within a room, or room blocks. The Wake-up Call feature is
functional with a PBX interface. If no active PBX interface functionality exists, it
is possible to use this feature to log manual wake up requests for reporting.
     */
namespace LodgerPms.Domain.Shared
{
    public class WakeUpCall : ValueObject<WakeUpCall>
    {
        public WakeUpCall(string room ,  DateTime begingDate, DateTime endDate, string fromTime, string toTime)
        {
            this.Room = room;
            this.BegingDate = begingDate;
            this.EndDate = endDate;
            this.FromTime = fromTime;
            this.ToTime = toTime;
            this.Description = Description;
        }
        public string Room { get; private set; }
        public DateTime BegingDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string FromTime { get; private set; }
        public string ToTime { get; private set; }

        public string Description { get; private set; }
        public WakeUpCallStatus Status { get; private set; }
    }
    public enum WakeUpCallStatus
    {
        Pending = 1,
        NoAnswer = 2,
        Completed = 3,
    }
}
