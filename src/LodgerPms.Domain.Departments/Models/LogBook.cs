using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments.Models
{
    public class LogBook: Identity
    {
        public LogBook()
        {
        }
        public string Department { get; private set; }
        public string Date { get; private set; }

        public string Description { get; private set; }
    }
}
