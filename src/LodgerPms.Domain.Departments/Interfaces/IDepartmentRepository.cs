
using LodgerPms.Domain.Departments.Models;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments.Interfaces
{

    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> GetByDescription(string description);
    }
}
