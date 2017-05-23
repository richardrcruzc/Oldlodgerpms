using LodgerPms.Departments.Api.Model;
using MediatR;
using System.Runtime.Serialization;

namespace LodgerPms.Departments.Api.Application.Commands.Departments
{
    [DataContract]
    public abstract class DepartmentCommand : Command,  IAsyncRequest<bool>
    {
        [DataMember]
        public string Id { get; protected set; }
        [DataMember]
        public Package Package { get; protected set; }
        [DataMember]
        public DepartmentGroup DepartmentGroup { get; protected set; }
        [DataMember]
        public DepartmentType DepartmentType { get; protected set; }
        [DataMember]
        public bool ApplyTax { get; protected set; }
        [DataMember]
        public decimal Amount { get; protected set; }
        [DataMember]
        public decimal Percentage { get; protected set; }
        [DataMember]
        public string Description { get; protected set; }

    }
}