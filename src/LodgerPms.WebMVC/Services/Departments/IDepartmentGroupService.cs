using LodgerPms.WebMVC.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.WebMVC.Services.Departments
{
    public interface IDepartmentGroupService 
    {
        Task<DepartmentGroupViewModel> GetDepartmentGroups(int page, int take);
        Task Create(DepartmentGroup depto);
        Task Update(DepartmentGroup depto);
        Task Delete(string id);
    }
}
