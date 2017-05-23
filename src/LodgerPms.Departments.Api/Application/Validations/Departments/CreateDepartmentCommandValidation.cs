using LodgerPms.Departments.Api.Application.Commands.Departments;
 

namespace LodgerPms.Departments.Api.Application.Validations.Departments
{
    public class CreateDepartmentCommandValidation : DepartmentValidation<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidation()
        {
            ValidateDescription();
        }
    }
}
