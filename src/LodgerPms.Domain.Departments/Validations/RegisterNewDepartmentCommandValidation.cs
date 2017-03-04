 using LodgerPms.Domain.Departments.Commands;

namespace LodgerPms.Domain.Departments.Validations
{
    public class RegisterNewDepartmentCommandValidation : DepartmentValidation<RegisterNewDepartmentCommand>
    {
        public RegisterNewDepartmentCommandValidation()
        {
            ValidateDescription();
        }
    }
}
