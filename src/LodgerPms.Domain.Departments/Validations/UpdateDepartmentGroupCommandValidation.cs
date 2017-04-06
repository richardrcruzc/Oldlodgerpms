
using LodgerPms.Domain.Departments.Commands;

namespace LodgerPms.Domain.Departments.Validations
{
    public class UpdateDepartmentGroupCommandValidation : DepartmentGroupValidation<UpdateDepartmentGroupCommand>
    {
        public UpdateDepartmentGroupCommandValidation()
        {

            ValidateDescription();

        }
    }
}
