using System;
using LodgerPms.Domain.Departments.Validations;

namespace LodgerPms.Domain.Departments.Commands
{
    public class RemoveFolioPatternCommand : FolioPatternCommand
    {
        public RemoveFolioPatternCommand(string id)
        {
            Id = id;
            //AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveFolioPatternCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}