using LodgerPms.CoreLibs.Domain;
using MediatR;

namespace LodgerPms.CoreLibs.Bus.Simple
{
    public interface ISimpleCommandHandler<T> : ICommandHandler, IAsyncNotificationHandler<T>
        where T : IAsyncNotification
    {
    }
}