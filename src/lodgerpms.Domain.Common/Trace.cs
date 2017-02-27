using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
Traces are internal interdepartmental messages that serve as reminders for other
employees.
Traces assist the hotel in taking actions on guests special requests.
     */
namespace lodgerpms.Domain.Common
{
    public class Trace : Identity
    {
        public Trace(DateTime date, string time, string department, string name)
        {
            this.Date = date;
            this.Time = time;
            this.Department = department;
            this.Name = name;

        }
        public DateTime Date { get; private set; }
        public string Time { get; private set; }
        public string Department { get; private set; }
        public string Name { get; private set; }

        public TraceStatus TraceStatus { get; private set; }

        public DateTime REsolvedOn { get; private set; }
        public string RevolvedBy { get; private set; }

    }
    public enum TraceStatus
    {
        NotReceived = 1,
        Received = 2,
    }
}
