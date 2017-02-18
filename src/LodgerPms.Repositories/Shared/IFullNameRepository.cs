
using LodgerPms.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Repositories.Agents
{
    public interface IFullNameRepository : IRepository<FullName>
    {
        Task<FullName> FindById(int id);
        Task<IEnumerable<FullName>> GetAll();
        Task<string> AddAndReturnKey(FullName aggregate);
        Task<bool> Update(FullName aggregate);
        Task<bool> Remove(FullName aggregate);

    }
}
