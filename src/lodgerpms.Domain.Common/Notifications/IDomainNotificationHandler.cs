

using lodgerpms.Domain.Common.Events;
using System.Collections.Generic;

namespace lodgerpms.Domain.Common.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : lodgerpms.Domain.Common.Events.Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
