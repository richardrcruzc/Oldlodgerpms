

using LodgerPms.Application.ViewModels.Deparments;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LodgerPms.UI.Site.ViewModel
{
    
    public class DepartmentListModel
    {
        public List<SelectListItem> DepartmentGroups { get; set; } = new List<SelectListItem>{};
       
        public List<SelectListItem> DepartmentTypes { get; set; } = new List<SelectListItem>{};

        public List<DepartmentViewModel> Departments { get; set; }
    }
}
