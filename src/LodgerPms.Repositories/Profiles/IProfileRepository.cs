using LodgerPms.Domain.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Repositories.Profiles
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task<Profile> FindById(int id);
        Task<IEnumerable<Profile>> GetAll();
        Task<string> AddAndReturnKey(Profile aggregate);
        Task<bool> Update(Profile aggregate);
        Task<bool> Remove(Profile aggregate);

    }
}
