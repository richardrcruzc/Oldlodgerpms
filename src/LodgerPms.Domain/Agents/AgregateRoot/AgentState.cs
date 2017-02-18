
namespace LodgerPms.Domain.Agents.AgregateRoot
{
    public class AgentState: Identity
    {
        
        public string ShippingAddressId { get;  set; }
        public string BillingAddressId { get;  set; }

    }
}
