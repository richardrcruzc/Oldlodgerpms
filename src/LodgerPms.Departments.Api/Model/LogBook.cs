
using LodgerPms.Domain.SeedWork;
using LodgerPms.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Model
{
    public class LogBook: Entity, IAggregateRoot
    {
        public LogBook()
        {
        }
        public string Department { get; private set; }
        public string Date { get; private set; }

        public string Description { get; private set; }
    }
}
