using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class PropertyDomainException : Exception
    {
        public PropertyDomainException()
        { }

        public PropertyDomainException(string message)
            : base(message)
        { }

        public PropertyDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
