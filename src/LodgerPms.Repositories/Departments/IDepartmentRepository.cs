
using LodgerPms.Domain.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Repositories.Agents
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> FindById(int id);
        Task<IEnumerable<Department>> GetAll();
        Task<string> AddAndReturnKey(Department aggregate);
        Task<bool> Update(Department aggregate);
        Task<bool> Remove(Department aggregate);

    }
}
