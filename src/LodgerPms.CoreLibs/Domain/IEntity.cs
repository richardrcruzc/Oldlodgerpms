using System;

namespace LodgerPms.CoreLibs.Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}