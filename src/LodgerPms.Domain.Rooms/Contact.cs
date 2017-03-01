
using lodgerpms.Domain.Common;

namespace LodgerPms.Domain.Rooms
{
    public class Contact : TestId
    {
        public string CompanyName { get; protected set; }
        public string EmailAddress { get; protected set; }
        public string Phone { get; protected set; }

        public FullName FullName { get; set; }
    }
}
