using lodgerpms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Bookings
{
    public class GroupInfo
    {
        public static GroupInfo CreateNew(string name, string description, string companyName, decimal creditLimit)
        {
            var obj = new GroupInfo {
                Name = name,
                Description =description,
                CompanyName = companyName,
                CreditLimit = creditLimit
            };
            return obj;

        }

        internal GroupInfo()
    {
            ContactInformation = new Collection<ContactInformation>();
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string CompanyName { get; private set; }
        public decimal CreditLimit { get; private set; }

        public ICollection<ContactInformation> ContactInformation { get; private set; }

        public GroupInfo SetGroupInfoContactDetails(ContactInformation info)
        {
            ContactInformation.Add(info);
            return this;
        }



    }

}
