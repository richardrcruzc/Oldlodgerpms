using LodgerPms.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Repositories.Agents
{
    public interface IRoomInfoRepository : IRepository<RoomInfo>
    {
        Task<RoomInfo> FindById(int id);
        Task<IEnumerable<RoomInfo>> GetAll();
        Task<string> AddAndReturnKey(RoomInfo aggregate);
        Task<bool> Update(RoomInfo aggregate);
        Task<bool> Remove(RoomInfo aggregate);

    }
}
