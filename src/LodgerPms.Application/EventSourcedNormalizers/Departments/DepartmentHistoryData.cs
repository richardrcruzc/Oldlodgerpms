using LodgerPms.Domain.Departments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Application.EventSourcedNormalizers.Departments
{
    public class DepartmentHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public Package Package { get;  set; }
        public DepartmentGroup DepartmentGroup { get;  set; }
        public DepartmentType DepartmentType { get;  set; }
        public bool ApplyTax { get;  set; }
        public decimal Amount { get;  set; }
        public decimal Percentage { get;  set; }
        public string Description { get;  set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
