
using LodgerPms.Domain.Departments.Models;
using LodgerPms.Domain.Interface.Interfaces;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Department GetByDescription(string description);

    }
}
