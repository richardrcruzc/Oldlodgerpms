 using LodgerPms.Domain.Departments.Commands;

namespace LodgerPms.Domain.Departments.Validations
{
    public class RegisterNewDepartmentGroupCommandValidation : DepartmentGroupValidation<RegisterNewDepartmentGroupCommand>
    {
        public RegisterNewDepartmentGroupCommandValidation()
        {
            ValidateDescription();
        }
    }
}
