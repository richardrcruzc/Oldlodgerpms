using System.Collections.Generic;
using LodgerPms.Domain.Core.Events;

namespace LodgerPms.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}