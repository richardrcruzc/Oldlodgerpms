

using LodgerPms.Departments.Api.Application.Validations.Departments;
using LodgerPms.Departments.Api.Model;

namespace LodgerPms.Departments.Api.Application.Commands.Departments
{
    public class UpdateDepartmentCommand : DepartmentCommand
    {
        public UpdateDepartmentCommand(string id, DepartmentGroup departmentGroup, DepartmentType departmentType, string description, bool applyTax, decimal amount, decimal percentage)
        {
            Id = id;
            DepartmentGroup = departmentGroup;
            DepartmentType = DepartmentType;
            ApplyTax = applyTax;
            Amount = amount;
            Percentage = percentage;
            Description = description;
        }

        public override bool IsValid()
        {
            //ValidationResult = new UpdateDepartmentCommandValidation().Validate(this);
            //return ValidationResult.IsValid;

            return true;
        }
    }
}