using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api
{
    // TODO: Rename DepartmentSettings for consistency?
    public class Settings
    {
        public string ExternalDepartmentBaseUrl { get; set; }
        public string EventBusConnection { get; set; }
    }
}
