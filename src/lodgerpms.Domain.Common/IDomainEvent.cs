using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lodgerpms.Domain.Common 
{
    public interface IDomainEvent
    {
        int EventVersion { get; set; }
        DateTime OccurredOn { get; set; }
    }
}
