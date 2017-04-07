
using LodgerPms.Domain.Core.Commands; 

namespace LodgerPms.Domain.Departments.Commands
{
    public abstract class DepartmentGroupCommand : Command
    {
        public string Id { get; protected set; } 
        public string Code { get; protected set; }
        public string Description { get; protected set; }

    }
}