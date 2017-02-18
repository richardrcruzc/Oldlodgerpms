using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LodgerPms.Domain.Agents;
using LodgerPms.Persistence.FaceCover;

namespace LodgerPms.Domain.Repositories.Agents
{
    public class AgentRepository : IAgentRepository
    {
        private readonly EFDomainDbContext _dbContext;

        public Task<bool> Add(Agent aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddAndReturnKey(Agent aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Agent aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Agent>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Agent> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Agent>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Agent aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Agent aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Agent aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
