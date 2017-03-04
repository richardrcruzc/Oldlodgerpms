
using LodgerPms.Domain.Core.Commands;
using LodgerPms.Domain.Departments.Models;

namespace LodgerPms.Domain.Departments.Commands
{
    public abstract class DepartmentCommand : Command
    {
        public string Id { get; protected set; }

        public Package Package { get; protected set; }
        public DepartmentGroup DepartmentGroup { get; protected set; }
        public DepartmentType DepartmentType { get; protected set; }
        public bool ApplyTax { get; protected set; }
        public decimal Amount { get; protected set; }
        public decimal Percentage { get; protected set; }
        public string Description { get; protected set; }

    }
}