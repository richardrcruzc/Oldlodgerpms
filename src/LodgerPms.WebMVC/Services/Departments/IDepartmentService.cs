using LodgerPms.WebMVC.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.WebMVC.Services.Departments
{
    public interface IDepartmentService 
    {
        Task<DepartmentViewModel> GetDepartments(int page, int take, string brand = null, string  type=null);
        Task<IEnumerable<SelectListItem>> GetDepartmentGroup();
        
        Task Create(Department depto);
        Task Update(Department depto);
        Task Delete(string id);
    }
}
