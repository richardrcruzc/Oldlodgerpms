
namespace LodgerPms.Departments.Api.Application.Commands.Departments
{
    public class RemoveDepartmentCommand : DepartmentCommand
    {
        public RemoveDepartmentCommand(string id)
        {
            Id = id;
            //AggregateId = id;
        }

        public override bool IsValid()
        {
            //ValidationResult = new RemoveDepartmentCommandValidation().Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }
    }
}