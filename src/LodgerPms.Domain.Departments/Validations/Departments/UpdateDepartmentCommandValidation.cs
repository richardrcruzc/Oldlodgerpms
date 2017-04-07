
using LodgerPms.Domain.Departments.Commands;

namespace LodgerPms.Domain.Departments.Validations
{
    public class UpdateDepartmentCommandValidation : DepartmentValidation<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidation()
        {

            ValidateDescription();

        }
    }
}
