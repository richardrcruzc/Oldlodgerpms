using System.Collections.Generic;

namespace LodgerPms.CoreLibs.Bus
{
    public interface ICommandConsumer : IMessageConsumer
    {
        IEnumerable<ICommandHandler> CommandHandlers { get; }
    }
}