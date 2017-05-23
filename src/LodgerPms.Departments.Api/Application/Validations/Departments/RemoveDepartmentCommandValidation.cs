
using LodgerPms.Departments.Api.Application.Commands.Departments;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Application.Validations.Departments
{

    public class RemoveDepartmentCommandValidation : DepartmentValidation<RemoveDepartmentCommand>
    {
        public RemoveDepartmentCommandValidation()
        {
           // ValidateId();
        }
    }
}
