using System;
using LodgerPms.Domain.Departments.Validations;

namespace LodgerPms.Domain.Departments.Commands
{
    public class RemoveDepartmentGroupCommand : DepartmentGroupCommand
    {
        public RemoveDepartmentGroupCommand(string id)
        {
            Id = id;
            //AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDepartmentGroupCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}