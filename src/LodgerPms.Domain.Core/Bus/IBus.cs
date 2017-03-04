using LodgerPms.Domain.Core.Commands;
using LodgerPms.Domain.Core.Events;

namespace LodgerPms.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}