using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Bookings
{
    public class block
    {
        public Booking AccountNumber { get; private set; }
        public DateTime ArrivalDate { get; private set; }
        public DateTime DepartureDate { get; private set; }
        public string Room { get; private set; }
        public bool InHouse { get; private set; }
        public string BlockDate { get; private set; }
         
    }
}
