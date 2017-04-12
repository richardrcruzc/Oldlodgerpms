using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.WebMVC.ViewModels.Departments
{
    public class Department
    {
        public string Package { get; private set; }
        public string DepartmentGroup { get; private set; }
        public string DepartmentType { get; private set; }
        public bool ApplyTax { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Percentage { get; private set; }
        public string Description { get; private set; }
    }
}
