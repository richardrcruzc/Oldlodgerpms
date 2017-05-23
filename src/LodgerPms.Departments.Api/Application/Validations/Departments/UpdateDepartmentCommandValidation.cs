

using LodgerPms.Departments.Api.Application.Commands.Departments;

namespace LodgerPms.Departments.Api.Application.Validations.Departments
{
    public class UpdateDepartmentCommandValidation : DepartmentValidation<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidation()
        {

            ValidateDescription();

        }
    }
}
