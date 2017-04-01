using System;
using LodgerPms.Domain.Departments.Validations;
using LodgerPms.Domain.Departments.Models;

namespace LodgerPms.Domain.Departments.Commands
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
            ValidationResult = new UpdateDepartmentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}