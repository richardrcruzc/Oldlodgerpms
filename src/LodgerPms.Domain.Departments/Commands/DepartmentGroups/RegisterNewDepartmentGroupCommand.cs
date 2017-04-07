using LodgerPms.Domain.Departments.Models;
using LodgerPms.Domain.Departments.Validations;
using System;

namespace LodgerPms.Domain.Departments.Commands
{
    public class RegisterNewDepartmentGroupCommand : DepartmentGroupCommand
    {
        public RegisterNewDepartmentGroupCommand(string code, string description)
        {
           
            this.Description = description;
            this.Code = code;
            

        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewDepartmentGroupCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}