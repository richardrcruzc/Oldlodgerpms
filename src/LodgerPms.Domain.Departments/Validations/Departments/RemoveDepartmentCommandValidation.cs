
using LodgerPms.Domain.Departments.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Domain.Departments.Validations
{

    public class RemoveDepartmentCommandValidation : DepartmentValidation<RemoveDepartmentCommand>
    {
        public RemoveDepartmentCommandValidation()
        {
           // ValidateId();
        }
    }
}
