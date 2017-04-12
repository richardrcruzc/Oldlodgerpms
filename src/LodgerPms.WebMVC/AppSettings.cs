using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.WebMVC
{
    
        public class AppSettings
        {
            public Connectionstrings ConnectionStrings { get; set; }
            public string DepartmentUrl { get; set; }
           
            public Logging Logging { get; set; }
        }

        public class Connectionstrings
        {
            public string DefaultConnection { get; set; }
        }

        public class Logging
        {
            public bool IncludeScopes { get; set; }
            public Loglevel LogLevel { get; set; }
        }

        public class Loglevel
        {
            public string Default { get; set; }
            public string System { get; set; }
            public string Microsoft { get; set; }
        }
    }
 
