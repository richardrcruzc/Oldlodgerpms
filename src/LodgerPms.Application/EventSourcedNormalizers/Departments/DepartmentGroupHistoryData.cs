using System;
using System.Collections.Generic;
using System.Text;

namespace LodgerPms.Application.EventSourcedNormalizers.Departments
{
    public class DepartmentGroupHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; } 
        public string Code { get; set; }
        public string Description { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
