using LodgerPms.Departments.Api.Model;
using LodgerPms.Domain.Events;
using System;
 

namespace LodgerPms.Departments.Api.Events.Departments
{
    public class DepartmentUpdatedEvent : Event
    {
        public DepartmentUpdatedEvent(DepartmentGroup departmentGroup, DepartmentType departmentType, string description, bool applyTax, decimal amount, decimal percentage)
        {
            // Id = id;
            DepartmentGroup = departmentGroup;
            DepartmentType = DepartmentType;
            ApplyTax = applyTax;
            Amount = amount;
            Percentage = percentage;
            Description = description;
        }
        public Guid Id { get; set; }
        public Package Package { get; private set; }
        public DepartmentGroup DepartmentGroup { get; private set; }
        public DepartmentType DepartmentType { get; private set; }
        public bool ApplyTax { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Percentage { get; private set; }
        public string Description { get; private set; }

    }
}