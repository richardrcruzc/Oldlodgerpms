using LodgerPms.Departments.Api.Model;
using LodgerPms.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Repository
{
    public interface IDepartmentGroupRepository : IRepository<DepartmentGroup>
    {
        DepartmentGroup Add(DepartmentGroup department);

        void Update(DepartmentGroup department);

        Task<DepartmentGroup> GetAsync(int departmentId);
    }
}
