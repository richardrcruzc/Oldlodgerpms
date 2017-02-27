
using lodgerpms.Domain.Common;

namespace LodgerPms.Domain.Agents.AgregateRoot
{
    public class AgentState: Identity, IAggregateRoot
    {
        
        public string ShippingAddressId { get;  set; }
        public string BillingAddressId { get;  set; }

    }
}
