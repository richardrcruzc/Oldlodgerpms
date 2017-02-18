using LodgerPms.Domain.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Repositories.Agents
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Task<Agent> FindById(int id);
        Task<IEnumerable<Agent>> GetAll();
        Task<string> AddAndReturnKey(Agent aggregate);
        Task<bool> Update(Agent aggregate);
        Task<bool> Remove(Agent aggregate);

    }
}
