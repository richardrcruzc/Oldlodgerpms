

using lodgerpms.Domain.Common.Commands;
using lodgerpms.Domain.Common.Events;

namespace lodgerpms.Domain.Common.IBus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
