

using LodgerPms.BookingsDataLayer;
using LodgerPms.Domain.Bookings;
using System;
using System.Linq;

namespace LodgerPms.AgentsDataLayer
{
    public class DbInitializer
    {
        public static void Initialize(BookingsContext cntxt)
        {
            if (!cntxt.Bookings.Any())
            {
                var b = Booking.CreateNew("AG-12",DateTime.Now, DateTime.Now.AddDays(1),false,null,0,0m,4,4,4,4,4,4,4,4,4);
                cntxt.Bookings.AddAsync(b);

            }
        }
    }

}
