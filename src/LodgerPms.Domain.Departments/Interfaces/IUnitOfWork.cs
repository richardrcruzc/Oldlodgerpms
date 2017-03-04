using lodgerpms.Domain.Common.Commands;
using System;


namespace LodgerPms.Domain.Departments.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
