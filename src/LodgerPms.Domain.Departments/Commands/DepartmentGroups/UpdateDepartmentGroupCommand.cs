using System;
using LodgerPms.Domain.Departments.Validations; 

namespace LodgerPms.Domain.Departments.Commands
{
    public class UpdateDepartmentGroupCommand : DepartmentGroupCommand
    {
        public UpdateDepartmentGroupCommand(string id, string code,  string description)
        {
            Id = id;
            Code = code;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateDepartmentGroupCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}