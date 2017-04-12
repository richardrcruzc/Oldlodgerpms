using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Infrastructure.Exceptions
{
     /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class DepartmentDomainException : Exception
    {
        public DepartmentDomainException()
        { }

        public DepartmentDomainException(string message)
            : base(message)
        { }

        public DepartmentDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
