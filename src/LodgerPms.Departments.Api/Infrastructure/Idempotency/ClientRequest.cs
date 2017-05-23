using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace   LodgerPms.Departments.Api.Infrastructure.Idempotency
{
    public class ClientRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}
