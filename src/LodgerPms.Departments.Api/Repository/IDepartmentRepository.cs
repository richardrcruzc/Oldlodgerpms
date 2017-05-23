using LodgerPms.Departments.Api.Model;
using LodgerPms.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Department Add(Department department);

        void Update(Department department);

        Task<Department> GetAsync(int departmentId);
    }
}
