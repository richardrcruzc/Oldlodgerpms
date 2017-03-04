using LodgerPms.Domain.Departments.Models;
using LodgerPms.Domain.Departments.Validations;
using System;

namespace LodgerPms.Domain.Departments.Commands
{
    public class RegisterNewDepartmentCommand : DepartmentCommand
    {
        public RegisterNewDepartmentCommand(DepartmentGroup departmentGroup, DepartmentType departmentType, string description, bool applyTax, decimal amount, decimal percentage)
        {
            this.DepartmentGroup = departmentGroup;
            this.DepartmentType = departmentType;
            this.Description = description;
            this.Amount = amount;
            this.ApplyTax = applyTax;



        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewDepartmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}