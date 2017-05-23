
using LodgerPms.Departments.Api.Application.Validations.Departments;
using LodgerPms.Departments.Api.Model;

namespace LodgerPms.Departments.Api.Application.Commands.Departments
{
    public class CreateDepartmentCommand : DepartmentCommand
    {
        public CreateDepartmentCommand(DepartmentGroup departmentGroup, DepartmentType departmentType, string description, bool applyTax, decimal amount, decimal percentage)
        {
            
            this.DepartmentGroup = departmentGroup;
            this.DepartmentType = departmentType;
            this.Description = description;
            this.Amount = amount;
            this.ApplyTax = applyTax;



        }

        public override bool IsValid()
        {
            //    ValidationResult = new RegisterNewDepartmentCommandValidation().Validate(this);
            //    return ValidationResult.IsValid;
            return true;
        }
    }
}