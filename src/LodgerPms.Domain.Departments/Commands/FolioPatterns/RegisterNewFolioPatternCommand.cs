using LodgerPms.Domain.Departments.Models;
using LodgerPms.Domain.Departments.Validations;
using System;

namespace LodgerPms.Domain.Departments.Commands
{
    public class RegisterNewFolioPatternCommand : FolioPatternCommand
    {
        public RegisterNewFolioPatternCommand(string code, string description)
        {
           
            this.Description = description;
            this.Code = code;
            

        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewFolioPatternCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}