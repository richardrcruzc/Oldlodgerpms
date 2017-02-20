using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Shared
{

    public class Locator : Identity
    {
        public  Locator(DateTime begingDate ,DateTime endDate ,string fromTime , string toTime)
        {
            this.BegingDate = begingDate;
            this.EndDate = endDate;
            this.FromTime = fromTime;
            this.ToTime = toTime;
            this.Description = Description;
        }
        public DateTime BegingDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string FromTime { get; private set; }
        public string ToTime { get; private set; }

        public string Description { get; private set; }
    }
}
