using LodgerPms.Domain.Rooms;
using LodgerPms.Domain.SeedWork;
using LodgerPms.Property.Api.Infrastructure.Data;
using LodgerPms.Property.Api.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.Repository
{
    

    public class RoomInfoRepository
        : IRoomInfoRepository
    {
        private readonly PropertyContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public RoomInfoRepository(PropertyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public RoomInfo Add(RoomInfo room)
        {
            return _context.RoomInfos.Add(room).Entity;

        }

        public async Task<RoomInfo> GetAsync(string id)
        {
            return await _context.RoomInfos.FindAsync(id);
        }

        public async Task<PaginatedItemsViewModel<RoomInfo>> GetAsync(int pageSize = 10,  int pageIndex = 0)
        {
            var totalItems = await _context.RoomInfos.LongCountAsync();

            var itemsOnPage = await _context.RoomInfos
               .OrderBy(c => c.Description)
               .Skip(pageSize * pageIndex)
               .Take(pageSize)
               .ToListAsync();

            var model = new PaginatedItemsViewModel<RoomInfo>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return model;
        }

        public void Update(RoomInfo room)
        {
            _context.Entry(room).State = EntityState.Modified;
        }

         
    }
}
