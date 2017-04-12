
using LodgerPms.Domain.SeedWork;
using LodgerPms.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Model
{
    public class Valet: Entity, IAggregateRoot
    {
        public  Valet()
        {
        }
            public string TicketNumber { get; private set; }
        public string Type { get; private set; }
        public string Action { get; private set; }
        public string Location { get; private set; }
        public string Reference { get; private set; }
        public string Description { get; private set; }
    }
}
