using System.Collections.Generic;

namespace LodgerPms.CoreLibs.Bus
{
    public interface IEventConsumer : IMessageConsumer
    {
        IEnumerable<IEventHandler> EventHandlers { get; }
    }
}