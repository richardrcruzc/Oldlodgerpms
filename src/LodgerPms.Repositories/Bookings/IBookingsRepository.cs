
using LodgerPms.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Repositories.Agents
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<Booking> FindById(int id);
        Task<IEnumerable<Booking>> GetAll();
        Task<string> AddAndReturnKey(Booking aggregate);
        Task<bool> Update(Booking aggregate);
        Task<bool> Remove(Booking aggregate);

    }
}
