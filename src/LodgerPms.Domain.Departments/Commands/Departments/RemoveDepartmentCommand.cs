using System;
using LodgerPms.Domain.Departments.Validations;

namespace LodgerPms.Domain.Departments.Commands
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
            ValidationResult = new RemoveDepartmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}