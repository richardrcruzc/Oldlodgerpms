using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.WebMVC.ViewModels.Departments
{
    public class DepartmentGroupViewModel 
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<DepartmentGroup> Data { get; set; }
    }
}
