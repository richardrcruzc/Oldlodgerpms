using System;
using LodgerPms.Domain.Departments.Validations; 

namespace LodgerPms.Domain.Departments.Commands
{
    public class UpdateFolioPatternCommand : FolioPatternCommand
    {
        public UpdateFolioPatternCommand(string id, string code,  string description)
        {
            Id = id;
            Code = code;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFolioPatternCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}