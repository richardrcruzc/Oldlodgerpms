using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api
{   
    public class DepartmentSettings
    {
        public string ExternalDepartmentBaseUrl { get; set; }
        public string EventBusConnection { get; set; }
    }
}
