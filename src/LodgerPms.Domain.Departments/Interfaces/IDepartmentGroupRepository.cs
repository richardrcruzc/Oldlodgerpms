
using LodgerPms.Domain.Departments.Models;
using LodgerPms.Domain.Interface.Interfaces;
 
namespace LodgerPms.Domain.Departments.Interfaces
{
    public interface IDepartmentGroupRepository : IRepository<DepartmentGroup>
    {
        DepartmentGroup GetByDescription(string description);

    }
}
