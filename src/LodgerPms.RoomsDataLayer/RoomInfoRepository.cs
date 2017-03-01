//using LodgerPms.Domain.Rooms;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace LodgerPms.RoomsDataLayer
//{
//    public class RoomInfoRepository: IRoomInfoRepository
//    {
//        private readonly RoomsContext _dbContext;
//        public RoomInfoRepository(RoomsContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<bool> Add(RoomInfo aggregate)
//        {
//            await _dbContext.RoomInfos.AddAsync(aggregate);
//            return await _dbContext.SaveChangesAsync() > 0;
//        }

//        public async Task<string> AddAndReturnKey(RoomInfo aggregate)
//        {
//            await _dbContext.RoomInfos.AddAsync(aggregate);
//            await _dbContext.SaveChangesAsync();

//            return  aggregate.Id;
//        }

//        public async Task<bool> Delete(RoomInfo aggregate)
//        {
//            _dbContext.RoomInfos.Remove(aggregate);
//            return await _dbContext.SaveChangesAsync() > 0;

//        }

//        public async Task<IList<RoomInfo>> FindAll()
//        {
//             var roomInfos = await (from o in _dbContext.RoomInfos select o).ToListAsync();
//            return roomInfos;
//             }

//        public async Task<RoomInfo> FindById(string id)
//        {
//            var myQuestion = await (from o in _dbContext.RoomInfos
//                     .Include(x => x.RoomLocation)
//                     .Include(x => x.RoomType)
//                     .Include(x => x.BedType)
//                                    where o.Id == id
//                                    select o).SingleAsync();
//            return myQuestion;

//        }

       
//        public async Task<bool> Remove(RoomInfo aggregate)
//        {
//            _dbContext.RoomInfos.Remove(aggregate);
//            return await _dbContext.SaveChangesAsync() > 0;

//        }

//        public async Task<bool> Save(RoomInfo aggregate)
//        {
//            var exist = await FindById(aggregate.Id);
//            if (exist != null)
//            {
//                exist.Update(exist.RoomNumber, exist.RoomType, exist.BedType, exist.RoomLocation, null);
                
//            }
//            _dbContext.RoomInfos.Update(exist);
//            return await _dbContext.SaveChangesAsync() > 0;

//        }
         
        
//    }

//}
