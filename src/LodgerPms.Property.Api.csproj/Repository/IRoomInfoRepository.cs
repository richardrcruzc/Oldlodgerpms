using LodgerPms.Domain.Rooms;
using LodgerPms.Domain.SeedWork;
using LodgerPms.Property.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.Repository
{
    public interface IRoomInfoRepository : IRepository<RoomInfo>
    {
        RoomInfo Add(RoomInfo room);

        void Update(RoomInfo room);

        Task<RoomInfo> GetAsync(string id);

        Task<PaginatedItemsViewModel<RoomInfo>> GetAsync(int pageSize = 10, int pageIndex = 0);
    }
}
