using LodgerPms.Domain.Core.Commands;
using System;


namespace LodgerPms.Domain.Interface.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
