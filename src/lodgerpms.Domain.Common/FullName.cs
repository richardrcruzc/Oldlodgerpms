using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lodgerpms.Domain.Common
{
    //no ID because it's a value object
    //EF will recognized this as a complex type
    //some methods borrowed from Vaughn Vernon IDDD.NET sample
    public class FullName : Identity
    {
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public FullName(FullName fullName)
          : this(fullName.FirstName, fullName.LastName)
        {
        }

        internal FullName()
        {
        }


        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string AsFormattedName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public FullName WithChangedFirstName(string firstName)
        {
            return new FullName(firstName, this.LastName);
        }

        public FullName WithChangedLastName(string lastName)
        {
            return new FullName(this.FirstName, lastName);
        }
        public override string ToString()
        {
            return "FullName [firstName=" + FirstName + ", lastName=" + LastName + "]";
        }
    }
}
